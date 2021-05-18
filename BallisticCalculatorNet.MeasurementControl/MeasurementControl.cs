using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        internal TextBox NumericPartControl => NumericPart;

        internal ComboBox UnitPartControl => UnitPart;

        public bool IsEmpty => NumericPartControl.Text.Length == 0;

        private void UpdateUnits()
        {
            UnitPart.Items.Clear();
            foreach (var unit in mController.GetUnits())
                UnitPart.Items.Add(unit);
            UnitPart.SelectedIndex = 0;
        }

        public object Value
        {
            get => mController.Value(NumericPart.Text, UnitPart.SelectedItem);
            set
            {
                mController.ParseValue(value, out var text, out var unit);
                NumericPart.Text = text;
                UnitPart.SelectedItem = unit;
            }
        }

        public Measurement<T> ValueAs<T>() where T : Enum
        {
            mController.ValidateUnitType<T>();
            return (Measurement<T>)Value;
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
                NumericPartControl.Text = mController.DoIncrement(NumericPartControl.Text, 1);
                e.Handled = true;
                Changed?.Invoke(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Down && e.Modifiers == Keys.None)
            {
                NumericPartControl.Text = mController.DoIncrement(NumericPartControl.Text, -1);
                e.Handled = true;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}