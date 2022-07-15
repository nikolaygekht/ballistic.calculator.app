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
                var bc = measurementBC.ValueAs<BallisticCoefficient>();
                if (checkBoxFormFactor.Checked)
                    bc = new BallisticCoefficient(bc.Value, bc.Table, BallisticCoefficientValueType.FormFactor);
                Ammunition ammo = new Ammunition()
                {
                    Weight = measurementBulletWeight.ValueAsMeasurement<WeightUnit>(),
                    MuzzleVelocity = measurementMuzzleVelocity.ValueAsMeasurement<VelocityUnit>(),
                    BallisticCoefficient = bc,
                    BulletDiameter = !measurementDiameter.IsEmpty ? measurementDiameter.ValueAsMeasurement<DistanceUnit>() : null,
                    BulletLength = !measurementLength.IsEmpty ? measurementLength.ValueAsMeasurement<DistanceUnit>() : null,
                };
                return ammo;
            }
            set
            {
                if (value == null)
                {
                    measurementBulletWeight.Value = measurementBulletWeight.UnitAs<WeightUnit>().New(0);
                    measurementMuzzleVelocity.Value = measurementMuzzleVelocity.UnitAs<VelocityUnit>().New(0);
                    measurementBC.Value = new BallisticCoefficient(0.5, DragTableId.G1);
                    checkBoxFormFactor.Checked = false;
                    measurementDiameter.Value = null;
                    measurementLength.Value = null;
                }
                else
                {
                    measurementBulletWeight.Value = value.Weight;
                    measurementMuzzleVelocity.Value = value.MuzzleVelocity;
                    measurementBC.Value = value.BallisticCoefficient;
                    checkBoxFormFactor.Checked = value.BallisticCoefficient.ValueType == BallisticCoefficientValueType.FormFactor;
                    measurementDiameter.Value = value.BulletDiameter;
                    measurementLength.Value = value.BulletLength;
                }
            }
        }

        public string CustomBallisticFile
        {
            get => textBoxCustomBallistic.Text;
            set 
            { 
                textBoxCustomBallistic.Text = value;
                if (string.IsNullOrEmpty(value) || !File.Exists(value))
                    CustomBallistic = null;
                else
                {
                    try
                    {
                        using var fs = new FileStream(value, FileMode.Open, FileAccess.Read, FileShare.Read);
                        CustomBallistic = DrgDragTable.Open(fs, Encoding.ASCII);
                        measurementBC.Value = new BallisticCoefficient(1, DragTableId.GC);
                        checkBoxFormFactor.Checked = true;
                        measurementBulletWeight.Value = CustomBallistic.Ammunition.Ammunition.Weight.To(WeightUnit.Gram);
                        if (CustomBallistic.Ammunition.Ammunition.BulletDiameter != null)
                            measurementDiameter.Value = CustomBallistic.Ammunition.Ammunition.BulletDiameter.Value.To(DistanceUnit.Millimeter);
                    }
                    catch (Exception)
                    {
                        CustomBallistic = null;
                        checkBoxFormFactor.Checked = false;
                    }
                }
                CustomTableChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public DrgDragTable CustomBallistic { get; private set; }

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
                    measurementLength.ChangeUnit(DistanceUnit.Millimeter, 2);
                    measurementDiameter.ChangeUnit(DistanceUnit.Millimeter, 2);
                    break;
                case MeasurementSystem.Imperial:
                    measurementBulletWeight.ChangeUnit(WeightUnit.Grain, 1);
                    measurementMuzzleVelocity.ChangeUnit(VelocityUnit.FeetPerSecond, 1);
                    measurementLength.ChangeUnit(DistanceUnit.Inch, 3);
                    measurementDiameter.ChangeUnit(DistanceUnit.Inch, 3);
                    break;
            }
        }

        private void AmmoControl_Enter(object sender, EventArgs e)
        {
            measurementBulletWeight.Focus();
        }

        public void Clear()
        {
            measurementBulletWeight.Value = null;
            measurementBC.Value = null;
            measurementMuzzleVelocity.Value = null;
            measurementLength.Value = null;
            measurementDiameter.Value = null;
        }

        private void buttonCustomBallisticLoad_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog()
            {
                Title = "Open drag table",
                Filter = "Drag Table (*.drg)|*.drg",
                CheckFileExists = true,
                CheckPathExists = true,
                ShowReadOnly = false,
                ShowHelp = false,
            };
            if (ofd.ShowDialog(this) == DialogResult.OK)
                CustomBallisticFile = ofd.FileName;
        }

        public event EventHandler CustomTableChanged;

        private void buttonSDasBC_Click(object sender, EventArgs e)
        {
            var weight = measurementBulletWeight.ValueAsMeasurement<WeightUnit>();
            var diameter = measurementDiameter.ValueAsMeasurement<DistanceUnit>();
            if (weight.Value != 0 && diameter.Value != 0)
            {
                measurementBC.Value = new BallisticCoefficient(Math.Round(weight.In(WeightUnit.Grain) / 7000.0 / Math.Pow(diameter.In(DistanceUnit.Inch), 2), 5), DragTableId.GC);
                checkBoxFormFactor.Checked = false;
            }
        }
    }
}
