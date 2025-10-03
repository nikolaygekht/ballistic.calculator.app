using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculator;
using BallisticCalculator.Reticle;
using BallisticCalculator.Reticle.Data;
using BallisticCalculator.Reticle.Draw;
using BallisticCalculator.Reticle.Graphics;
using BallisticCalculator.Serialization;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.Types;
using Gehtsoft.Measurements;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BallisticCalculatorNet.InputPanels
{
    public partial class ReticleControl : UserControl
    {
        private ReticleDefinition mCurrentReticle;

        private MeasurementSystem mMeasurementSystem;

        public MeasurementSystem MeasurementSystem
        {
            get => mMeasurementSystem;
            set
            {
                mMeasurementSystem = value;
                comboBoxTargetSizeUnits.SelectedIndex = value == MeasurementSystem.Imperial ? 0 : 1;
                var distanceUnits = value == MeasurementSystem.Imperial ? DistanceUnit.Yard : DistanceUnit.Meter;
                if (measurementTargetDistance.IsEmpty)
                    measurementTargetDistance.Value = 100.As(distanceUnits);
                else
                    measurementTargetDistance.ChangeUnit(distanceUnits, 0);
                UpdateReticle();
            }

        }

        private TrajectoryToReticleCalculator mReticleCalculator;
        private ShotData mShotData;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ShotData ShotData { 
            get => mShotData;
            set
            {
                mShotData = value;
                UpdateReticleCalc();
                UpdateReticle();
            }
        }

        public ReticleControl()
        {
            InitializeComponent();
            mCurrentReticle = new MilDotReticle();
        }

        private void UpdateReticleCalc()
        {
            mReticleCalculator = new TrajectoryToReticleCalculator(mShotData, mCurrentReticle.BulletDropCompensator, mShotData.Weapon.Zero.Distance);
        }

        private void UpdateReticle()
        {
            if (mCurrentReticle == null)
            {
                pictureReticle.Image = null;
                return;
            }

            var scaleFactor = ReticleControlHelper.GetReticleScaleFactor(numericCurrentZoom, numericMaxZoom);
            var bdc = ReticleControlHelper.CreateBdc(mReticleCalculator, mMeasurementSystem, radioBDCNone, radioBDCFar, scaleFactor);
            var target = ReticleControlHelper.CreateTarget(mReticleCalculator, checkBoxShowTarget, numericTargetWidth, numericTargetHeight, comboBoxTargetSizeUnits, measurementTargetDistance, scaleFactor);

            ReticleControlHelper.GetReticleCanvasSize(mCurrentReticle, pictureReticle, out int width, out int height);
            var image = new Bitmap(width, height);
            var canvas = GraphicsCanvas.FromImage(image, Color.White);

            ReticleDrawController controller = new ReticleDrawController(mCurrentReticle, canvas);
            canvas.Clear();

            if (target != null)
                controller.DrawElement(target);

            controller.DrawReticle();

            if (bdc != null && bdc.Count > 0)
                foreach (var element in bdc)
                    controller.DrawElement(element);

            pictureReticle.Image = image;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            UpdateReticle();
        }

        private void buttonLoadReticle_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                DefaultExt = ".reticle",
                Filter = "Reticles (*.reticle)|*.reticle|All files (*.*)|*.*",
                CheckFileExists = true,
                Title = "Open..."
            };

            if (ControlConfiguration.Configuration["datafolder"] != null)
            {
                dlg.InitialDirectory = ControlConfiguration.Configuration["datafolder"];
                dlg.RestoreDirectory = false;
            }
            else
                dlg.RestoreDirectory = true;


            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    using var fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    {
                        mCurrentReticle = fs.BallisticXmlDeserialize<ReticleDefinition>();
                        UpdateReticleCalc();
                        UpdateReticle();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Can't open the file {dlg.FileName}\r\nError: {ex.Message}\r\nTo log the error details enable the warning log level and try operation again");
                    ControlConfiguration.Logger?.Warning(ex, $"Loading file '{dlg.FileName}' failed");
                }
            }
        }

        private void buttonMilDot_Click(object sender, EventArgs e)
        {
            mCurrentReticle = new MilDotReticle();
            UpdateReticleCalc();
            UpdateReticle();
        }

        private void numericCurrentZoom_ValueChanged(object sender, EventArgs e)
        {
            UpdateReticle();
        }

        private void numericMaxZoom_ValueChanged(object sender, EventArgs e)
        {
            UpdateReticle();
        }

        private void checkBoxShowTarget_CheckedChanged(object sender, EventArgs e)
        {
            UpdateReticle();
        }

        private void radioBDCNone_CheckedChanged(object sender, EventArgs e)
        {
            UpdateReticle();
        }

        private void radioBDCNear_CheckedChanged(object sender, EventArgs e)
        {
            UpdateReticle();
        }

        private void radioBDCFar_CheckedChanged(object sender, EventArgs e)
        {
            UpdateReticle();
        }

        private void numericTargetWidth_ValueChanged(object sender, EventArgs e)
        {
            UpdateReticle();
        }

        private void numericTargetHeight_ValueChanged(object sender, EventArgs e)
        {
            UpdateReticle();
        }

        private void comboBoxTargetSizeUnits_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateReticle();
        }

        private void measurementTargetDistance_Changed(object sender, EventArgs e)
        {
            UpdateReticle();
        }

        private void splitContainer1_SizeChanged(object sender, EventArgs e)
        {
            UpdateReticle();
        }
    }
}
