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
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.ReticleEditor
{
    public partial class AppForm : Form
    {
        internal string ReticleFileName { get; private set;  } = null;

        internal ReticleDefinition Reticle { get; private set; } = new ReticleDefinition();

        public AppForm()
        {
            InitializeComponent();
            NewReticle();
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
                LoadReticle(dlg.FileName);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ReticleFileName))
                buttonSaveAs_Click(sender, e);
            SaveReticle();
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
                SaveReticleAs(dlg.FileName);
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
    }
}
