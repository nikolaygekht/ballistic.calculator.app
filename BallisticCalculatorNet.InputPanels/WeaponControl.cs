using BallisticCalculator;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.InputPanels.DataList;
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
    public interface IWeaponControl
    {
        MeasurementSystem MeasurementSystem { get; set; }
        Measurement<AngularUnit> VertialClick { get; }
        Rifle Rifle { get; set; }
    }

    public partial class WeaponControl : UserControl, IWeaponControl
    {
        public WeaponControl()
        {
            InitializeComponent();
            comboBoxRiflingDirection.SelectedIndex = 0;
            measurementRifling.Enabled = false;
            measurementVClick.Value = null;
            measurementHClick.Value = null; 
            measurementVerticalOffset.Enabled = false;
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
                if (ZeroAtmosphere != null)
                    ZeroAtmosphere.MeasurementSystem = value;
                if (ZeroAmmunition != null)
                    ZeroAmmunition.MeasurementSystem = value;
                UpdateSystem();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Measurement<AngularUnit> VertialClick => measurementVClick.ValueAsMeasurement<AngularUnit>();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IZeroAtmosphereControl ZeroAtmosphere { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IZeroAmmunitionControl ZeroAmmunition { get; set; }

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
                        Distance = measurementZeroDistance.ValueAsMeasurement<DistanceUnit>(),
                        Atmosphere = ZeroAtmosphere?.Atmosphere,
                        Ammunition = ZeroAmmunition?.Ammunition,
                        VerticalOffset = checkBoxZeroVerticalOffset.Checked ? measurementVerticalOffset.ValueAsMeasurement<DistanceUnit>() : null
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
                    },
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
                    if (ZeroAmmunition != null)
                        ZeroAmmunition.Ammunition = null;
                    if (ZeroAtmosphere != null)
                        ZeroAtmosphere.Atmosphere = null;
                }
                else
                {
                    measurementZeroDistance.Value = value.Zero.Distance;
                    if (ZeroAmmunition != null)
                        ZeroAmmunition.Ammunition = value.Zero.Ammunition;
                    if (ZeroAtmosphere != null)
                        ZeroAtmosphere.Atmosphere = value.Zero.Atmosphere;
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

                if (value?.Zero?.VerticalOffset != null)
                {
                    checkBoxZeroVerticalOffset.Checked = true;
                    measurementVerticalOffset.Enabled = true;
                    measurementVerticalOffset.Value = value.Zero.VerticalOffset.Value;
                }
                else
                {
                    checkBoxZeroVerticalOffset.Checked = false;
                    measurementVerticalOffset.Enabled = false;
                    measurementVerticalOffset.Value = null;
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
                measurementVerticalOffset.ChangeUnit(DistanceUnit.Millimeter, 0);
            }
            else if (mMeasurementSystem == MeasurementSystem.Imperial)
            {
                measurementSightHeight.ChangeUnit(DistanceUnit.Inch, 1);
                measurementZeroDistance.ChangeUnit(DistanceUnit.Yard, 0);
                measurementRifling.ChangeUnit(DistanceUnit.Inch, 1);
                measurementVerticalOffset.ChangeUnit(DistanceUnit.Inch, 1);
            }
        }

        private void comboBoxRiflingDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            measurementRifling.Enabled = comboBoxRiflingDirection.SelectedIndex != 0;
        }

        private void checkBoxZeroVerticalOffset_CheckedChanged(object sender, EventArgs e)
        {
            measurementVerticalOffset.Enabled = checkBoxZeroVerticalOffset.Checked;
        }

        private void buttonSightDictionary_Click(object sender, EventArgs e)
        {
            var dictionary = DataItemDictonaryFactory.Get();
            if (dictionary == null || dictionary.Sights == null || dictionary.Sights.Count == 0)
            {
                MessageBox.Show(this, "Dictionary does not exist in data folder or cannot be read.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var dialog = new DataListItemSelector()
            {
                Text = "Sights",
                Items = dictionary.Sights
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (dialog.SelectedItem is SightListItem item)
                {
                    measurementSightHeight.Value = item.SightHeight;
                    measurementZeroDistance.Value = item.DefaultZero;
                    if (item.HorizontalClick != null)
                        measurementHClick.Value = item.HorizontalClick.Value;
                    if (item.VerticalClick != null)
                        measurementVClick.Value = item.VerticalClick.Value;
                }
            }
        }

        private void buttonRiflingDictionary_Click(object sender, EventArgs e)
        {
            var dictionary = DataItemDictonaryFactory.Get();
            if (dictionary == null || dictionary.Barrels == null || dictionary.Barrels.Count == 0)
            {
                MessageBox.Show(this, "Dictionary does not exist in data folder or cannot be read.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var dialog = new DataListItemSelector()
            {
                Text = "Barrels",
                Items = dictionary.Barrels
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (dialog.SelectedItem is BarrelListItem item)
                {
                    measurementRifling.Value = item.Step;
                    comboBoxRiflingDirection.SelectedIndex = item.TwistDirection == TwistDirection.Left ? 1 : 2;
                }
            }
        }
    }
}
