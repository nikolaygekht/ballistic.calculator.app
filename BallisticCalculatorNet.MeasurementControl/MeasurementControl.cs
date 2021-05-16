using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculatorNet.MeasurementControl;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.ReticleEditor
{
    public partial class MeasurementControl : UserControl
    {
        private MeasurementType mMeasurementType = MeasurementType.Distance;
        private MeasurementUtility mMeasurementUtility = MeasurementTools.Instance.GetUtility(MeasurementType.Distance);

        public MeasurementType MeasurementType {
            get => mMeasurementType;
            set
            {
                mMeasurementType = value;
                mMeasurementUtility = MeasurementTools.Instance.GetUtility(value);
                UpdateUnits();
            }
        }

        public MeasurementControl()
        {
            InitializeComponent();
            UpdateUnits();
        }

        public int DecimalPlaces
        {
            get => numericPart.DecimalPlaces;
            set => numericPart.DecimalPlaces = value;
        }

        public decimal Increment
        {
            get => numericPart.Increment;
            set => numericPart.Increment = value;
        }

        public decimal Minimum
        {
            get => numericPart.Minimum;
            set => numericPart.Minimum = value;
        }

        public decimal Maximum 
        {
            get => numericPart.Maximum;
            set => numericPart.Maximum = value;
        }

        internal NumericUpDown NumericPart => numericPart;

        internal ComboBox UnitPart => unitPart;


        private void UpdateUnits()
        {
            unitPart.Items.Clear();
            foreach (var unit in mMeasurementUtility.Units)
                unitPart.Items.Add(unit);
            unitPart.SelectedIndex = 0;
        }

        public object Value
        {
            get
            {
                decimal v = numericPart.Value;
                object u = (unitPart.SelectedItem as MeasurementUtility.Unit).Value;
                return mMeasurementUtility.Activator((double)v, u);
            }
            set
            {
                numericPart.Value = (decimal)mMeasurementUtility.ValueGetter(value);
                
                object u = mMeasurementUtility.UnitGetter(value);

                foreach (var unit in unitPart.Items)
                {
                    var _unit = unit as MeasurementUtility.Unit;
                    if (_unit.Value.Equals(u))
                    {
                        unitPart.SelectedItem = _unit;
                    }
                }
            }
        }

        public Measurement<T> ValueAs<T>() where T : Enum
        {
            if (typeof(T) != mMeasurementUtility.MeasurementUnit)
                throw new InvalidOperationException($"An attempt to read a values of type {typeof(T).Name} from the control that hold value of type {mMeasurementUtility.MeasurementUnit.Name}");

            return (Measurement<T>) Value;
        }

        private void MeasurementControl_Enter(object sender, EventArgs e)
        {
            numericPart.Focus();
        }

        private void MeasurementControl_Resize(object sender, EventArgs e)
        {
            numericPart.Size = new Size(this.Width - unitPart.Size.Width, numericPart.Size.Height);
            unitPart.Location = new Point(this.Width - unitPart.Size.Width, 0);
        }
    }
}

