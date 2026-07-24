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
                                Math.Abs(measurementShotAngle.ValueAsMeasurement<AngularUnit>().In(AngularUnit.MOA)) < 0.0001 ? null : measurementShotAngle.ValueAsMeasurement<AngularUnit>(),
                    ShotDropAdjustment = ClicksToAngle((int)numericVerticalCorrection.Value, WeaponControl?.VertialClick),
                    ShotWindageAdjustment = ClicksToAngle((int)numericHorizontalCorrection.Value, WeaponControl?.HorizontalClick),
                };
            }
            set
            {
                if (value == null)
                {
                    measurementDistance.Value = 1000.As(mMeasurementSystem == MeasurementSystem.Metric ? DistanceUnit.Meter : DistanceUnit.Yard);
                    measurementStep.Value = 100.As(mMeasurementSystem == MeasurementSystem.Metric ? DistanceUnit.Meter : DistanceUnit.Yard);
                    measurementShotAngle.Value = null;
                    numericVerticalCorrection.Value = 0;
                    numericHorizontalCorrection.Value = 0;
                }
                else
                {
                    measurementDistance.Value = value.MaximumDistance;
                    measurementStep.Value = value.Step;
                    measurementShotAngle.Value = value.ShotAngle;
                    numericVerticalCorrection.Value = ClampToRange(AngleToClicks(value.ShotDropAdjustment, WeaponControl?.VertialClick), numericVerticalCorrection);
                    numericHorizontalCorrection.Value = ClampToRange(AngleToClicks(value.ShotWindageAdjustment, WeaponControl?.HorizontalClick), numericHorizontalCorrection);
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

        /// <summary>
        /// Converts a number of scope clicks entered by the user into an angular adjustment
        /// using the sight's click value. Returns null when there is no correction to apply.
        /// </summary>
        private static Measurement<AngularUnit>? ClicksToAngle(int clicks, Measurement<AngularUnit>? click)
        {
            if (click == null || clicks == 0)
                return null;
            return click.Value * clicks;
        }

        /// <summary>
        /// Converts a stored angular adjustment back into a whole number of scope clicks for display.
        /// Returns zero when there is no correction.
        /// </summary>
        private static decimal AngleToClicks(Measurement<AngularUnit>? angle, Measurement<AngularUnit>? click)
        {
            if (angle == null || click == null || Math.Abs(click.Value.Value) < 1e-9)
                return 0;
            return (int)Math.Round(angle.Value.In(click.Value.Unit) / click.Value.Value);
        }

        private static decimal ClampToRange(decimal value, NumericUpDown control)
            => Math.Clamp(value, control.Minimum, control.Maximum);
    }
}
