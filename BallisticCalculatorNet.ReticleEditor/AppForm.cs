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

        internal void LoadReticle(Stream reticleStream, string fileName)
        {
            Reticle = reticleStream.BallisticXmlDeserialize<ReticleDefinition>();
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
    }
}
