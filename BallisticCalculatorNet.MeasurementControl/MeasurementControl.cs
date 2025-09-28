using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculatorNet.MeasurementControl;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.MeasurementControl
{
    public partial class MeasurementControl : UserControl
    {
        private readonly MeasurmentControlController mController;

        public MeasurementType MeasurementType
        {
            get => mController.MeasurementType;
            set
            {
                mController.MeasurementType = value;
                UpdateUnits();
            }
        }

        public MeasurementControl()
        {
            mController = new MeasurmentControlController();
            InitializeComponent();
            UpdateUnits();
        }

        public double Increment
        {
            get => mController.Increment;
            set => mController.Increment = value;
        }

        public double Minimum
        {
            get => mController.Minimum;
            set => mController.Minimum = value;
        }

        public double Maximum
        {
            get => mController.Maximum;
            set => mController.Maximum = value;
        }

        public int? DecimalPoints
        {
            get => mController.DecimalPoints;
            set => mController.DecimalPoints = value;
        }

        public bool IsEmpty => NumericPart.Text.Length == 0;

        private void UpdateUnits()
        {
            UnitPart.Items.Clear();
            int defaultIndex;
            foreach (var unit in mController.GetUnits(out defaultIndex))
                UnitPart.Items.Add(unit);
            UnitPart.SelectedIndex = defaultIndex;
        }

        public string TextValue
        {
            get => NumericPart.Text + UnitPart.SelectedItem.ToString();

            set
            {
                mOrgText = null;
                mOrgUnit = null;

                var units = mController.GetUnits(out int defaultIndex);
                if (string.IsNullOrEmpty(value))
                {
                    NumericPart.Text = "";
                    UnitPart.SelectedIndex = defaultIndex;
                    return;
                }

                int index = -1;
                foreach (var name in units.Select(x => x.Name))
                {
                    index++;
                    if (value.EndsWith(name))
                    {
                        NumericPart.Text = value.Substring(0, value.Length - name.Length);
                        UnitPart.SelectedIndex = index;
                        return;
                    }
                }

                NumericPart.Text = value;
                UnitPart.SelectedIndex = defaultIndex;
            }
        }

        private object mOldValue = null;
        private string mOrgText = null;
        private MeasurementUtility.Unit mOrgUnit = null;

        public object Value
        {
            get
            {

                if (mOrgText == NumericPart.Text && mOldValue != null && mOrgUnit != null && object.Equals(Unit, mOrgUnit.Value))
                    return mOldValue;
                return mController.Value(NumericPart.Text, UnitPart.SelectedItem, DecimalPoints);
            }
            set
            {
                if (value == null)
                {
                    NumericPart.Text = "";
                    mOrgUnit = (MeasurementUtility.Unit)UnitPart.SelectedItem;
                }
                else
                {
                    mController.ParseValue(value, out var text, out var unit);
                    NumericPart.Text = text;
                    UnitPart.SelectedItem = unit;
                    mOrgUnit = unit;
                }
                mOrgText = NumericPart.Text;
                mOldValue = value;
                
            }
        }

        public Measurement<T> ValueAsMeasurement<T>() where T : Enum
        {
            mController.ValidateUnitType<T>();
            return (Measurement<T>)Value;
        }

        public T ValueAs<T>() where T : struct
        {
            mController.ValidateType<T>();
            return (T)Value;
        }

        public T UnitAs<T>() where T : Enum
        {
            mController.ValidateUnitType<T>();
            var unit = (MeasurementUtility.Unit)UnitPart.SelectedItem;
            return (T)unit.Value;
        }

        public object Unit
        {
            get => ((MeasurementUtility.Unit)UnitPart.SelectedItem).Value;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                mController.ValidateUnitType(value.GetType());
                UnitPart.SelectedItem = mController.GetUnit(value);
            }
        }

        public void ForceCulture(CultureInfo cultureInfo)
        {
            object value = null;
            if (NumericPart.Text.Length > 0)
                value = Value;
            mController.Culture = cultureInfo;
            if (value != null)
                Value = value;
        }

        private void MeasurementControl_Enter(object sender, EventArgs e)
        {
            NumericPart.Focus();
        }

        private void NumericPart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
                return;

            if (!mController.AllowKeyInEditor(NumericPart.Text, NumericPart.SelectionStart, NumericPart.SelectionLength, e.KeyChar))
                e.Handled = true;
        }

        public event EventHandler Changed;

        private void NumericPart_TextChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(this, EventArgs.Empty);
        }

        private void UnitPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(this, EventArgs.Empty);
        }

        private void NumericPart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && e.Modifiers == Keys.None)
            {
                NumericPart.Text = mController.DoIncrement(NumericPart.Text, 1);
                e.Handled = true;
                Changed?.Invoke(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Down && e.Modifiers == Keys.None)
            {
                NumericPart.Text = mController.DoIncrement(NumericPart.Text, -1);
                e.Handled = true;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        public void ChangeUnit<T>(T unit, int? accuracy = null) where T : Enum
        {
            mController.ValidateUnitType<T>();
            bool empty = IsEmpty;
            var value = ValueAsMeasurement<T>();
            var v = value.In(unit);
            DecimalPoints = accuracy;
            Value = new Measurement<T>(v, unit);
            if (empty)
                NumericPart.Text = "";
        }
    }
}