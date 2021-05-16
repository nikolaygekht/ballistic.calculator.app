using System;
using System.Collections.Generic;
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

        public bool Metric { get; set; } = true;

        public double Increment { get; set; } = 1;

        internal CultureInfo Culture { get; set; } = CultureInfo.CurrentUICulture;

        public double Minimum { get; set; } = -10000;

        public double Maximum { get; set; } = 10000;

        internal TextBox NumericPartControl => NumericPart;

        internal ComboBox UnitPartControl => UnitPart;

        private void UpdateUnits()
        {
            UnitPart.Items.Clear();
            foreach (var unit in mMeasurementUtility.Units)
                UnitPart.Items.Add(unit);
            UnitPart.SelectedIndex = 0;
        }

        public object Value
        {
            get
            {
                double v;
                if (NumericPart.Text.Length == 0)
                    v = 0;
                else 
                    v = double.Parse(NumericPart.Text, Culture);
                object u = ((MeasurementUtility.Unit)UnitPart.SelectedItem).Value;
                return mMeasurementUtility.Activator(v, u);
            }
            set
            {
                NumericPart.Text = mMeasurementUtility.ValueGetter(value).ToString(Culture);
                object u = mMeasurementUtility.UnitGetter(value);

                foreach (var unit in UnitPart.Items)
                {
                    var _unit = unit as MeasurementUtility.Unit;
                    if (_unit.Value.Equals(u))
                    {
                        UnitPart.SelectedItem = _unit;
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

        public void ForceCulture(CultureInfo cultureInfo) => Culture = cultureInfo;

        private void MeasurementControl_Enter(object sender, EventArgs e)
        {
            NumericPart.Focus();
        }

        private void NumericPart_KeyPress(object sender, KeyPressEventArgs e)
        {
            int position = NumericPart.SelectionStart + NumericPart.SelectionLength;
            string beforeSelect = NumericPart.Text.Substring(0, NumericPart.SelectionStart);
            string afterSelect = position < NumericPart.Text.Length ? NumericPart.Text.Substring(position) : "";

            if (e.KeyChar == '+' || e.KeyChar == '-')
            {
                if (NumericPart.Text.Length == 0)
                    return;

                if (position == 0 && !NumericPart.Text.Contains("+") && !NumericPart.Text.Contains('-'))
                    return;
            }
            else if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                if (afterSelect.Length == 0 || (!afterSelect.Contains('+') && !afterSelect.Contains('-')))
                    return;
            }
            else if (e.KeyChar == Culture.NumberFormat.NumberDecimalSeparator[0])
            {
                if (position > 0 && !NumericPart.Text.Contains(Culture.NumberFormat.NumberDecimalSeparator[0]))
                    return;
            }
            else if (e.KeyChar == Culture.NumberFormat.NumberGroupSeparator[0])
            {
                if (position > 0 && !afterSelect.Contains("+") && !afterSelect.Contains("-"))
                    return;
            }
            e.Handled = true;   //ignore key
        }
    }
}