using System;
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
        private string mReticleName;

        internal string ReticleFileName { 
            get => mReticleName; 
            private set
            {
                mReticleName = value;
                UpdateText();
            }
        }

        internal ReticleDefinition Reticle { get; private set; } = new ReticleDefinition();

        private bool mChanged;

        internal bool Changed { 
            get => mChanged;
            private set
            {
                mChanged = value;
                UpdateText();
            }
        }

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
            Changed = false;
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
            Changed = false;
        }

        internal void SaveReticle(Stream reticleStream)
        {
            GatherReticleDefinition();
            Reticle.BallisticXmlSerialize(reticleStream);
            Changed = false;
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
            if (Reticle.Size == null)
            {
                pictureReticle.Image = null;
                return;
            }

            object selection = null;
            if (checkBoxHighlihtCurrent.Checked)
                selection = reticleItems.SelectedItem;

            CalculateReticleImageSize(pictureReticle.Size.Width, pictureReticle.Size.Height,
                                      Reticle.Size.X, Reticle.Size.Y, out int imageX, out int imageY);

            Bitmap bm = new Bitmap(imageX, imageY);
            GraphicsCanvas canvas = GraphicsCanvas.FromImage(bm, Color.White);
            ReticleDrawController controller = new ReticleDrawController(Reticle, canvas);
            canvas.Clear();

            if (Reticle.Elements.Count != 0)
            {
                controller.DrawReticle();

                if (selection is ReticleElement selectedReticleElement)
                {
                    var clone = selectedReticleElement.Clone();
                    var colorProperty = clone.GetType().GetProperty("Color");
                    if (colorProperty != null)
                    {
                        colorProperty.SetValue(clone, "blue");
                        controller.DrawElement(clone);
                    }
                }
            }

            if (Reticle.BulletDropCompensator.Count > 0)
            {
                for (int i = 0; i < Reticle.BulletDropCompensator.Count; i++)
                {
                    var bdc = Reticle.BulletDropCompensator[i];
                    string color = (selection != null && ReferenceEquals(selection, bdc)) ? "blue" : "darkblue";

                    controller.DrawElement(new ReticleCircle()
                    {
                        Center = bdc.Position,
                        Radius = Reticle.Size.X / 50,
                        Color = color,
                        Fill = false,
                        LineWidth = null,
                    });

                    controller.DrawElement(new ReticleText()
                    {
                        Position = new ReticlePosition(bdc.Position.X + bdc.TextOffset, bdc.Position.Y - bdc.TextHeight / 2),
                        Color = color,
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
            bool removed = false;
            if (item is ReticleElement el)
            {
                for (int i = 0; i < Reticle.Elements.Count; i++)
                    if (ReferenceEquals(el, Reticle.Elements[i]))
                    {
                        Reticle.Elements.RemoveAt(i);
                        removed = true;
                        break;
                    }
            }
            else if (item is ReticleBulletDropCompensatorPoint pt)
            {
                for (int i = 0; i < Reticle.BulletDropCompensator.Count; i++)
                    if (ReferenceEquals(pt, Reticle.BulletDropCompensator[i]))
                    {
                        Reticle.BulletDropCompensator.RemoveAt(i);
                        removed = true;
                        break;
                    }
            }
            if (removed)
            {
                for (int i = 0; i < reticleItems.Items.Count; i++)
                    if (ReferenceEquals(reticleItems.Items[i], item))
                    {
                        reticleItems.Items.RemoveAt(i);
                        i--;
                    }
            }
        }

        internal void DuplicateItem(object item)
        {
            if (item is ReticleElement reticleElement)
            {
                var clone = reticleElement.Clone();
                Reticle.Elements.Add(clone);
                reticleItems.Items.Add(clone);
            }
            else if (item is ReticleBulletDropCompensatorPoint bdc)
            {
                var clone = bdc.Clone();
                Reticle.BulletDropCompensator.Add(clone);
                reticleItems.Items.Add(clone);
            }
        }

        internal Form FormForObject(object obj)
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
            else if (obj is ReticlePath)
                type = typeof(EditPathForm);

            if (type == null)
                throw new ArgumentException($"The object type is not supported ({obj.GetType().Name})", nameof(obj));

            var constructor = type.GetConstructor(new Type[] { obj.GetType() }) ?? type.GetConstructor(new Type[] { obj.GetType(), typeof(ReticleDefinition) });

            if (constructor == null)
                throw new ArgumentException($"The form does not have a constructor that supports ({obj.GetType().Name})", nameof(obj));

            object[] args;

            if (constructor.GetParameters().Length == 2)
                args = new object[] { obj, Reticle };
            else
                args = new object[] { obj };

            return (Form)constructor.Invoke(args);
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
                Changed = true;
                UpdateImage();
            }
        }

        private void UpdateText() => this.Text = "Reticle Editor - [" + (mReticleName ?? "New Reticle") + "]" + (mChanged ? "*" : "");

        private void buttonSet_Click(object sender, EventArgs e)
        {
            GatherReticleDefinition();
            Changed = true;
            UpdateImage();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (mChanged && !OkToContinueOnChanged())
                return;

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
            Changed = true;
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
                Changed = true;
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

        private void reticleItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBoxHighlihtCurrent.Checked)
                UpdateImage();
        }

        private void checkBoxHighlihtCurrent_CheckedChanged(object sender, EventArgs e)
        {
            UpdateImage();
        }

        private void buttonDuplicate_Click(object sender, EventArgs e)
        {
            if (reticleItems.SelectedItem == null)
            {
                MessageBox.Show(this, "Select Item To Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DuplicateItem(reticleItems.SelectedItem);
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (mChanged && !OkToContinueOnChanged())
                return;
            NewReticle();
            UpdateImage();
        }

        private void buttonNewPath_Click(object sender, EventArgs e)
        {
            ReticlePath r = new ReticlePath()
            {
                Color = "black",
            };
            NewElement(r);
        }

        private bool OkToContinueOnChanged()
        {
            return !this.Visible ||
                MessageBox.Show(this, "The reticle is changed. If you continue, all changes will be lost. Do you want to proceed?", 
                                       "Reticle Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mChanged && !OkToContinueOnChanged())
                e.Cancel = true;
        }
    }
}
