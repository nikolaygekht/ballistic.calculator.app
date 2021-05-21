﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculator.Reticle.Data;
using BallisticCalculator.Reticle.Draw;
using BallisticCalculator.Reticle.Graphics;
using BallisticCalculator.Serialization;
using BallisticCalculatorNet.ReticleEditor.Forms;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.ReticleEditor
{
    public partial class AppForm : Form
    {
        internal string ReticleFileName { get; private set;  } = null;

        internal ReticleDefinition Reticle { get; private set; } = new ReticleDefinition();

        public AppForm(string fileToOpen = null)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(fileToOpen))
                NewReticle();
            else
            {
                try
                {
                    LoadReticle(fileToOpen);
                }
                catch (IOException e)
                {
                    MessageBox.Show($"Can't read file {fileToOpen}\r\n{e.Message}", "I/O error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Program.Logger?.Warning(e, $"Can't open file {fileToOpen}");
                    NewReticle();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Can't read reticle from {fileToOpen}\r\n{e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Program.Logger?.Warning(e, $"Can't open file {fileToOpen}");
                    NewReticle();
                }
            }
        }

        internal void LoadReticle(string fileName)
        {
            using var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            LoadReticle(fs, fileName);
        }

        internal void SaveReticleAs(string fileName)
        {
            ReticleFileName = fileName;
            SaveReticle();
        }

        internal void SaveReticle()
        {
            if (string.IsNullOrEmpty(ReticleFileName))
                throw new InvalidOperationException("The reticle is a new reticle. Save it specifying the name");
            using var fs = new FileStream(ReticleFileName, FileMode.Create, FileAccess.Write, FileShare.None);
            SaveReticle(fs);
        }

        internal void LoadReticle(Stream reticleStream, string fileName) =>
            LoadReticle(reticleStream.BallisticXmlDeserialize<ReticleDefinition>(), fileName);

        internal void LoadReticle(ReticleDefinition definition, string fileName)
        {
            Reticle = definition;
            ReticleFileName = fileName;
            UpdateReticle();
        }

        internal void NewReticle()
        {
            Reticle = new ReticleDefinition()
            {
                Name = "",
                Size = new ReticlePosition(10, 10, AngularUnit.Mil),
                Zero = new ReticlePosition(5, 5, AngularUnit.Mil),
            };
            ReticleFileName = null;
            UpdateReticle();
        }

        internal void SaveReticle(Stream reticleStream)
        {
            GatherReticleDefinition();
            Reticle.BallisticXmlSerialize(reticleStream);
        }

        internal void UpdateReticle()
        {
            reticleName.Text = Reticle.Name;
            reticleWidth.Value = Reticle.Size.X;
            reticleHeight.Value = Reticle.Size.Y;
            zeroOffsetX.Value = Reticle.Zero.X;
            zeroOffsetY.Value = Reticle.Zero.Y;

            reticleItems.Items.Clear();
            for (int i = 0; i < Reticle.Elements.Count; i++)
                reticleItems.Items.Add(Reticle.Elements[i]);

            for (int i = 0; i < Reticle.BulletDropCompensator.Count; i++)
                reticleItems.Items.Add(Reticle.BulletDropCompensator[i]);

            UpdateImage();
        }

        internal void GatherReticleDefinition()
        {
            Reticle.Name = reticleName.Text;
            Reticle.Size.X = reticleWidth.ValueAs<AngularUnit>();
            Reticle.Size.Y = reticleHeight.ValueAs<AngularUnit>();
            Reticle.Zero.X = zeroOffsetX.ValueAs<AngularUnit>();
            Reticle.Zero.Y = zeroOffsetY.ValueAs<AngularUnit>();
        }

        internal string GetInitialDirectory()
        {
            if (!string.IsNullOrEmpty(ReticleFileName))
            {
                var fi = new FileInfo(ReticleFileName);
                return fi.DirectoryName;
            }
            else
            {
                var fi = new FileInfo(Assembly.GetEntryAssembly().Location);
                return fi.DirectoryName;
            }
        }

        internal void UpdateImage()
        {
            if (Reticle.Elements.Count == 0)
                return;

            CalculateReticleImageSize(pictureReticle.Size.Width, pictureReticle.Size.Height,
                                      Reticle.Size.X, Reticle.Size.Y, out int imageX, out int imageY);

            Bitmap bm = new Bitmap(imageX, imageY);
            GraphicsCanvas canvas = GraphicsCanvas.FromImage(bm, Color.White);
            ReticleDrawController controller = new ReticleDrawController(Reticle, canvas);
            canvas.Clear();
            controller.DrawReticle();
            if (Reticle.BulletDropCompensator.Count > 0)
            {
                for (int i = 0; i < Reticle.BulletDropCompensator.Count; i++)
                {
                    var bdc = Reticle.BulletDropCompensator[i];
                    controller.DrawElement(new ReticleCircle()
                    {
                        Center = bdc.Position,
                        Radius = Reticle.Size.X / 50,
                        Color = "blue",
                        Fill = false,
                        LineWidth = null,
                    });

                    controller.DrawElement(new ReticleText()
                    {
                        Position = new ReticlePosition(bdc.Position.X + bdc.TextOffset, bdc.Position.Y - bdc.TextHeight / 2),
                        Color = "blue",
                        TextHeight = bdc.TextHeight,
                        Text = bdc.Position.Y.ToString(),
                    });
                }
            }
            pictureReticle.Image = bm;
        }

        internal static void CalculateReticleImageSize(int placeHolderWidth, int placeHolderHeight, Measurement<AngularUnit> reticleWidth, Measurement<AngularUnit> reticleHeight, out int imageWidth, out int imageHeight)
        {
            double reticleProprotion = reticleWidth / reticleHeight;

            if (placeHolderHeight * reticleProprotion > placeHolderWidth)
            {
                imageWidth = placeHolderWidth;
                imageHeight = (int)(placeHolderWidth / reticleProprotion);
            }
            else
            {
                imageHeight = placeHolderHeight;
                imageWidth = (int)(placeHolderHeight * reticleProprotion);
            }
        }

        internal void DeleteItem(object item)
        {
            if (item is ReticleElement el)
            {
                for (int i = 0; i < Reticle.Elements.Count; i++)
                    if (ReferenceEquals(el, Reticle.Elements[i]))
                    {
                        Reticle.Elements.RemoveAt(i);
                        reticleItems.Items.Remove(item);
                        break;
                    }
            }
            else if (item is ReticleBulletDropCompensatorPoint pt)
            {
                for (int i = 0; i < Reticle.BulletDropCompensator.Count; i++)
                    if (ReferenceEquals(pt, Reticle.BulletDropCompensator[i]))
                    {
                        Reticle.BulletDropCompensator.RemoveAt(i);
                        reticleItems.Items.Remove(item);
                        break;
                    }
            }
        }

        internal static Form FormForObject(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            Type type = null;
            if (obj is ReticleCircle)
                type = typeof(EditCircleForm);
            else if (obj is ReticleLine)
                type = typeof(EditLineForm);
            else if (obj is ReticleRectangle)
                type = typeof(EditRectangleForm);
            else if (obj is ReticleText)
                type = typeof(EditTextForm);
            else if (obj is ReticleBulletDropCompensatorPoint)
                type = typeof(EditBdcForm);

            if (type == null)
                throw new ArgumentException($"The object type is not supported ({obj.GetType().Name})", nameof(obj));

            var constructor = type.GetConstructor(new Type[] { obj.GetType() });

            if (constructor == null)
                throw new ArgumentException($"The form does not have a constructor that supports ({obj.GetType().Name})", nameof(obj));

            return (Form)constructor.Invoke(new object[] { obj });
        }

        internal Measurement<AngularUnit> ToReticleUnits(Measurement<AngularUnit> value) => value.To(reticleWidth.UnitAs<AngularUnit>());

        internal ReticlePosition ToReticleUnits(ReticlePosition value) => new ReticlePosition() { X = ToReticleUnits(value.X), Y = ToReticleUnits(value.Y) };

        private void NewElement(object element)
        {
            var form = FormForObject(element);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                reticleItems.Items.Add(element);
                reticleItems.SelectedIndex = reticleItems.Items.Count - 1;
                if (element is ReticleBulletDropCompensatorPoint bdc)
                    Reticle.BulletDropCompensator.Add(bdc);
                else if (element is ReticleElement el)
                    Reticle.Elements.Add(el);
                UpdateImage();
            }
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            GatherReticleDefinition();
            UpdateImage();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                DefaultExt = ".reticle",
                InitialDirectory = GetInitialDirectory(),
                Filter = FILTER,
                CheckFileExists = true,
                Title = "Open..."
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    LoadReticle(dlg.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Can't open the file {dlg.FileName}\r\nError: {ex.Message}\r\nTo log the error details enable the warning log level and try operation again");
                    Program.Logger?.Warning(ex, $"Loading file '{dlg.FileName}' failed");
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ReticleFileName))
                buttonSaveAs_Click(sender, e);
            else
            {
                try
                {
                    SaveReticle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Can't save the file {ReticleFileName}\r\nError: {ex.Message}\r\nTo log the error details enable the warning log level and try operation again");
                    Program.Logger?.Warning(ex, $"Saving file '{ReticleFileName}' failed");
                }
            }
        }

        private const string FILTER = "Reticle files|*.reticle|All Files|*.*";

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog()
            {
                DefaultExt = ".reticle",
                InitialDirectory = GetInitialDirectory(),
                Filter = FILTER,
                OverwritePrompt = true,
                CheckPathExists = true,
                Title = "Save As..."
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    SaveReticleAs(dlg.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Can't save the file {dlg.FileName}\r\nError: {ex.Message}\r\nTo log the error details enable the warning log level and try operation again");
                    Program.Logger?.Warning(ex, $"Saving file '{dlg.FileName}' failed");
                }
            }
        }

        private void splitContainer1_Panel1_SizeChanged(object sender, EventArgs e)
        {
            UpdateImage();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (reticleItems.SelectedItem == null)
            {
                MessageBox.Show(this, "Select Item To Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DeleteItem(reticleItems.SelectedItem);
            UpdateImage();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (reticleItems.SelectedItem == null)
            {
                MessageBox.Show(this, "Select Item To Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var form = FormForObject(reticleItems.SelectedItem);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var idx = reticleItems.SelectedIndex;
                var it = reticleItems.SelectedItem;
                reticleItems.Items.RemoveAt(idx);
                reticleItems.Items.Insert(idx, it);
                reticleItems.SelectedIndex = idx;

                UpdateImage();
            }
        }

        private void reticleItems_DoubleClick(object sender, EventArgs e) => buttonEdit_Click(sender, e);

        private void buttonNewCircle_Click(object sender, EventArgs e)
        {
            ReticleCircle circle = new ReticleCircle()
            {
                Center = ToReticleUnits(new ReticlePosition(0, 0, AngularUnit.Mil)),
                Radius = ToReticleUnits(AngularUnit.Mil.New(1)),
                LineWidth = null,
                Color = "black",
                Fill = false
            };
            NewElement(circle);
        }

        private void buttonNewLine_Click(object sender, EventArgs e)
        {
            ReticleLine line = new ReticleLine()
            {
                Start = ToReticleUnits(new ReticlePosition(0, 0, AngularUnit.Mil)),
                End = ToReticleUnits(new ReticlePosition(0, 0, AngularUnit.Mil)),
                LineWidth = null,
                Color = "black",
            };
            NewElement(line);
        }

        private void buttonNewRect_Click(object sender, EventArgs e)
        {
            ReticleRectangle r = new ReticleRectangle()
            {
                TopLeft = ToReticleUnits(new ReticlePosition(0, 0, AngularUnit.Mil)),
                Size = ToReticleUnits(new ReticlePosition(0, 0, AngularUnit.Mil)),
                LineWidth = null,
                Color = "black",
                Fill = false,
            };
            NewElement(r);
        }

        private void buttonNewText_Click(object sender, EventArgs e)
        {
            ReticleText r = new ReticleText()
            {
                Position = ToReticleUnits(new ReticlePosition(0, 0, AngularUnit.Mil)),
                TextHeight = ToReticleUnits(AngularUnit.Mil.New(0.5)),
                Color = "black",
                Text = ""
            };
            NewElement(r);
        }

        private void buttonNewBdcPoint_Click(object sender, EventArgs e)
        {
            ReticleBulletDropCompensatorPoint r = new ReticleBulletDropCompensatorPoint()
            {
                Position = ToReticleUnits(new ReticlePosition(0, -1, AngularUnit.Mil)),
                TextHeight = ToReticleUnits(AngularUnit.Mil.New(0.5)),
                TextOffset = ToReticleUnits(AngularUnit.Mil.New(0.5)),
            };
            NewElement(r);
        }
    }
}
