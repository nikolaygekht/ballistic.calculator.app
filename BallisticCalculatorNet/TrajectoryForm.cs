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

    public partial class TrajectoryForm : Form
    {
        private ShotData mShotData = null;
        private MeasurementSystem mMeasurementSystem = MeasurementSystem.Imperial;
        private TrajectoryPoint[] mTrajectory;
        private AngularUnit mAngularUnits = AngularUnit.Mil;

        public MeasurementSystem MeasurementSystem
        {
            get => mMeasurementSystem;
            set
            {
                mMeasurementSystem = value;
                trajectoryControl.MeasurementSystem = value;
                chartControl.MeasurementSystem = value;
                
            }
        }

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

        public ShotData ShotData
        {
            get => mShotData;
            set
            {
                mShotData = value;
                var calc = new TrajectoryCalculator();
                var zeroAmmo = mShotData.Weapon.Zero.Ammunition ?? mShotData.Ammunition.Ammunition;

                mShotData.Parameters.SightAngle = calc.SightAngle(zeroAmmo,
                                            mShotData.Weapon,
                                            (mShotData.Weapon.Zero.Atmosphere ?? mShotData.Atmosphere) ?? new Atmosphere(),
                                            GetDragTable(zeroAmmo));

                var trajectory = calc.Calculate(mShotData.Ammunition.Ammunition, mShotData.Weapon,
                    mShotData.Atmosphere ?? new Atmosphere(), mShotData.Parameters, mShotData.Wind?.ToArray(),
                    GetDragTable(mShotData.Ammunition.Ammunition));

                mTrajectory = trajectory;
                trajectoryControl.Sight = mShotData.Weapon.Sight;
                trajectoryControl.Trajectory = trajectory;
                chartControl.Trajectory = trajectory;

                Text = string.IsNullOrEmpty(mShotData.Ammunition.Name) ? 
                            $"Trajectory: New ammunition"
                          : $"Trajectory: {mShotData.Ammunition.Name})";
            }
        }

        public TrajectoryChartMode ChartMode
        {
            get => chartControl.ChartMode;
            set => chartControl.ChartMode = value;
        }

        public TrajectoryPoint[] Trajectory => mTrajectory;

        public string FileName { get; set; }

        public TrajectoryForm()
        {
            InitializeComponent();
            this.LoadFormState(Program.Configuration, "trajectory", true);
            chartControl.AngularUnits = mAngularUnits;
            trajectoryControl.AngularUnits = mAngularUnits;
        }

        private static DragTable GetDragTable(Ammunition ammo)
        {
            if (ammo == null || ammo.BallisticCoefficient.Table != DragTableId.GC ||
                string.IsNullOrEmpty(ammo.CustomTableFileName) || !File.Exists(ammo.CustomTableFileName))
                return null;
            return DrgDragTable.Open(ammo.CustomTableFileName);
        }

        private void TrajectoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            trajectoryControl.OnClose();
        }

        public void ShowTable() => tabControl.SelectedIndex = 0;
        public void ShowChart() => tabControl.SelectedIndex = 1;
        public void ShowReticle() => tabControl.SelectedIndex = 2;
    }
}
