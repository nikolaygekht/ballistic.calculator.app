using BallisticCalculator;
using BallisticCalculatorNet.Common;
using BallisticCalculatorNet.InputPanels;
using Gehtsoft.Measurements;
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

namespace BallisticCalculatorNet
{
    public partial class TrajectoryForm : Form, ITrajectoryDisplayForm, IChartDisplayForm
    {
        private ShotData mShotData = null;
        private TrajectoryPoint[] mTrajectory;
        
        private MeasurementSystem mMeasurementSystem = MeasurementSystem.Imperial;
        private AngularUnit mAngularUnits = AngularUnit.Mil;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasurementSystem MeasurementSystem
        {
            get => mMeasurementSystem;
            set
            {
                mMeasurementSystem = value;
                trajectoryControl.MeasurementSystem = value;
                chartControl.MeasurementSystem = value;
                reticleControl.MeasurementSystem = value;
                
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AngularUnit AngularUnits
        {
            get => mAngularUnits;
            set
            {
                mAngularUnits = value;
                trajectoryControl.AngularUnits = mAngularUnits;
                chartControl.AngularUnits = mAngularUnits;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ShotData ShotData
        {
            get => mShotData;
            set
            {
                mShotData = value;
                var trajectory = TrajectoryPointsCalculator.Calculate(mShotData);
                mTrajectory = trajectory;
                trajectoryControl.Sight = mShotData.Weapon.Sight;
                trajectoryControl.Trajectory = trajectory;
                chartControl.Trajectory = trajectory;
                reticleControl.ShotData = mShotData;

                Text = string.IsNullOrEmpty(mShotData.Ammunition.Name) ? 
                            $"Trajectory: New ammunition"
                          : $"Trajectory: {mShotData.Ammunition.Name}";
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TrajectoryChartMode ChartMode
        {
            get => chartControl.ChartMode;
            set => chartControl.ChartMode = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TrajectoryPoint[] Trajectory => mTrajectory;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FileName { get; set; }

        public TrajectoryForm()
        {
            InitializeComponent();
            this.LoadFormState(Program.Configuration, "trajectory", true);
            chartControl.AngularUnits = mAngularUnits;
            trajectoryControl.AngularUnits = mAngularUnits;
        }

        private void TrajectoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            trajectoryControl.OnClose();
        }

        public void ShowTable() => tabControl.SelectedIndex = 0;
        public void ShowChart() => tabControl.SelectedIndex = 1;
        public void ShowReticle() => tabControl.SelectedIndex = 2;

        public void UpdateYToVisibleArea()
        {
            chartControl.UpdateYAxis();
        }
    }
}
