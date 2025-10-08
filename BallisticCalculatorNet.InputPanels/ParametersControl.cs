using BallisticCalculator;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.Types;
using Gehtsoft.Measurements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet.InputPanels
{
    public partial class ParametersControl : UserControl
    {
        public ParametersControl()
        {
            InitializeComponent();
        }

        private MeasurementSystem mMeasurementSystem = MeasurementSystem.Metric;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasurementSystem MeasurementSystem
        {
            get => mMeasurementSystem;
            set
            {
                mMeasurementSystem = value;
                UpdateSystem();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ShotParameters Parameters
        {
            get
            {
                return new ShotParameters()
                {
                    MaximumDistance = measurementDistance.ValueAsMeasurement<DistanceUnit>(),
                    Step = measurementStep.ValueAsMeasurement<DistanceUnit>(),
                    ShotAngle = measurementShotAngle.IsEmpty ||
                                Math.Abs(measurementShotAngle.ValueAsMeasurement<AngularUnit>().In(AngularUnit.MOA)) < 0.0001 ? null : measurementShotAngle.ValueAsMeasurement<AngularUnit>()
                };
            }
            set
            {
                if (value == null)
                {
                    measurementDistance.Value = 1000.As(mMeasurementSystem == MeasurementSystem.Metric ? DistanceUnit.Meter : DistanceUnit.Yard);
                    measurementStep.Value = 100.As(mMeasurementSystem == MeasurementSystem.Metric ? DistanceUnit.Meter : DistanceUnit.Yard);
                    measurementShotAngle.Value = null;
                }
                else
                {
                    measurementDistance.Value = value.MaximumDistance;
                    measurementStep.Value = value.Step;
                    measurementShotAngle.Value = value.ShotAngle;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public IWeaponControl WeaponControl { get; set; }

        private void UpdateSystem()
        {
            if (mMeasurementSystem == MeasurementSystem.Metric)
            {
                measurementDistance.ChangeUnit(DistanceUnit.Meter, 0);
                measurementStep.ChangeUnit(DistanceUnit.Meter, 0);
            }
            else if (mMeasurementSystem == MeasurementSystem.Imperial)
            {
                measurementDistance.ChangeUnit(DistanceUnit.Yard, 0);
                measurementStep.ChangeUnit(DistanceUnit.Yard, 0);
            }
        }

        private void buttonClicksSet_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxClicks.Text, NumberStyles.Integer, CultureInfo.CurrentCulture, out var clicks))
                return;
            if (WeaponControl == null)
                return;
            measurementShotAngle.Value = clicks * WeaponControl.VertialClick;
        }
    }
}
