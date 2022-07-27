using BallisticCalculator;
using Gehtsoft.Measurements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet.InputPanels
{
    public partial class WeaponControl : UserControl
    {
        public WeaponControl()
        {
            InitializeComponent();
            comboBoxRiflingDirection.SelectedIndex = 0;
            measurementRifling.Enabled = false;
            measurementVClick.Value = 0.25.As(AngularUnit.MOA);
            measurementHClick.Value = 0.25.As(AngularUnit.MOA);
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
        public Rifle Rifle
        {
            get
            {
                TwistDirection? twist = comboBoxRiflingDirection.SelectedIndex switch
                {
                    1 => TwistDirection.Left,
                    2 => TwistDirection.Right,
                    _ => null
                };

                return new Rifle()
                {

                    Zero = new ZeroingParameters()
                    {
                        Distance = measurementZeroDistance.ValueAsMeasurement<DistanceUnit>()
                    },
                    Rifling = twist == null ? null :
                              new Rifling()
                              {
                                  Direction = twist.Value,
                                  RiflingStep = measurementRifling.ValueAsMeasurement<DistanceUnit>()
                              },
                    Sight = new Sight()
                    {
                        SightHeight = measurementSightHeight.ValueAsMeasurement<DistanceUnit>(),
                        VerticalClick = measurementVClick.ValueAsMeasurement<AngularUnit>(),
                        HorizontalClick = measurementHClick.ValueAsMeasurement<AngularUnit>()
                    }
                };
            }
            set
            {
                if (value?.Rifling == null)
                {
                    comboBoxRiflingDirection.SelectedIndex = 0;
                    measurementRifling.Value = null;
                    measurementRifling.Enabled = false;
                }
                else
                {
                    comboBoxRiflingDirection.SelectedIndex = value.Rifling.Direction == TwistDirection.Left ? 1 : 2;
                    measurementRifling.Enabled = true;
                    measurementRifling.Value = value.Rifling.RiflingStep;
                }

                if (value?.Zero == null)
                {
                    measurementZeroDistance.Value = mMeasurementSystem == MeasurementSystem.Metric ?
                                                   100.As(DistanceUnit.Meter) :
                                                   25.As(DistanceUnit.Yard);
                }
                else
                {
                    measurementZeroDistance.Value = value.Zero.Distance;
                }

                if (value?.Sight == null)
                {
                    measurementSightHeight.Value = mMeasurementSystem == MeasurementSystem.Metric ?
                                                   50.As(DistanceUnit.Millimeter) :
                                                   2.6.As(DistanceUnit.Inch);
                    measurementVClick.Value = 0.25.As(AngularUnit.MOA);
                    measurementHClick.Value = 0.25.As(AngularUnit.MOA);
                }
                else
                {
                    measurementSightHeight.Value = value.Sight.SightHeight;
                    measurementVClick.Value = value.Sight.VerticalClick ?? 0.25.As(AngularUnit.MOA);
                    measurementHClick.Value = value.Sight.HorizontalClick ?? 0.25.As(AngularUnit.MOA);
                }
            }
        }

        private void UpdateSystem()
        {
            if (mMeasurementSystem == MeasurementSystem.Metric)
            {
                measurementSightHeight.ChangeUnit(DistanceUnit.Millimeter, 0);
                measurementZeroDistance.ChangeUnit(DistanceUnit.Meter, 0);
                measurementRifling.ChangeUnit(DistanceUnit.Millimeter, 0);
            }
            else if (mMeasurementSystem == MeasurementSystem.Imperial)
            {
                measurementSightHeight.ChangeUnit(DistanceUnit.Inch, 1);
                measurementZeroDistance.ChangeUnit(DistanceUnit.Yard, 0);
                measurementRifling.ChangeUnit(DistanceUnit.Inch, 1);
            }
        }

        private void comboBoxRiflingDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            measurementRifling.Enabled = comboBoxRiflingDirection.SelectedIndex != 0;
        }
    }
}
