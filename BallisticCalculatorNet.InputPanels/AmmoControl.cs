using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculator;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.InputPanels
{
    public partial class AmmoControl : UserControl, IMeasurementSystemControl
    {
        private MeasurementSystem mMeasurementSystem = MeasurementSystem.Metric;

        public MeasurementSystem MeasurementSystem
        {
            get => mMeasurementSystem;
            set
            {
                mMeasurementSystem = value;
                UpdateSystem();
            }
        }

        public Ammunition Ammunition
        {
            get
            {
                Ammunition ammo = new Ammunition()
                {
                    Weight = measurementBulletWeight.ValueAs<WeightUnit>(),
                    MuzzleVelocity = measurementMuzzleVelocity.ValueAs<VelocityUnit>(),
                    BulletDiameter = checkBoxDimensions.Checked ? measurementDiameter.ValueAs<DistanceUnit>() : null,
                    BulletLength = checkBoxDimensions.Checked ? measurementLength.ValueAs<DistanceUnit>() : null,
                };
                return ammo;
            }
            set
            {
                if (value == null)
                {
                    measurementBulletWeight.Value = measurementBulletWeight.UnitAs<WeightUnit>().New(0);
                    measurementMuzzleVelocity.Value = measurementMuzzleVelocity.UnitAs<VelocityUnit>().New(0);
                    measurementDiameter.Value = measurementDiameter.UnitAs<DistanceUnit>().New(0);
                    measurementLength.Value = measurementLength.UnitAs<DistanceUnit>().New(0);
                }
                else
                {
                    measurementBulletWeight.Value = value.Weight;
                    measurementMuzzleVelocity.Value = value.MuzzleVelocity;
                    checkBoxDimensions.Checked = value.BulletDiameter != null && value.BulletLength != null;
                    measurementDiameter.Value = value.BulletDiameter ?? measurementDiameter.UnitAs<DistanceUnit>().New(0);
                    measurementLength.Value = value.BulletLength ?? measurementLength.UnitAs<DistanceUnit>().New(0);
                }
            }
        }


        public AmmoControl()
        {
            InitializeComponent();
        }



        private void UpdateSystem()
        {
            switch (mMeasurementSystem)
            {
                case MeasurementSystem.Metric:
                    measurementBulletWeight.ChangeUnit(WeightUnit.Gram, 2);
                    measurementMuzzleVelocity.ChangeUnit(VelocityUnit.MetersPerSecond, 1);
                    measurementLength.ChangeUnit(DistanceUnit.Millimeter, 1);
                    measurementDiameter.ChangeUnit(DistanceUnit.Millimeter, 1);
                    break;
                case MeasurementSystem.Imperial:
                    measurementBulletWeight.ChangeUnit(WeightUnit.Grain, 1);
                    measurementMuzzleVelocity.ChangeUnit(VelocityUnit.FeetPerSecond, 1);
                    measurementLength.ChangeUnit(DistanceUnit.Inch, 2);
                    measurementDiameter.ChangeUnit(DistanceUnit.Inch, 2);
                    break;
            }
        }

        private void UpdateDimension()
        {
            measurementDiameter.Enabled = checkBoxDimensions.Checked;
            measurementLength.Enabled = checkBoxDimensions.Checked;
        }

        internal void checkBoxDimensions_CheckedChanged(object sender, EventArgs e) => UpdateDimension();
    }
}
