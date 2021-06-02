using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.MeasurementControl
{
    internal class MeasurmentControlController
    {
        private MeasurementType mMeasurementType = MeasurementType.Distance;
        private MeasurementUtility mMeasurementUtility = MeasurementTools.Instance.GetUtility(MeasurementType.Distance);

        public MeasurementType MeasurementType
        {
            get => mMeasurementType;
            set
            {
                mMeasurementType = value;
                mMeasurementUtility = MeasurementTools.Instance.GetUtility(value);
            }
        }

        public double Minimum { get; set; } = -10000;
        public double Maximum { get; set; } = 10000;
        public double Increment { get; set; } = 1;

        public IEnumerable<MeasurementUtility.Unit> GetUnits(out int defaultIndex)
        {
            if (MeasurementType == MeasurementType.Distance)
                defaultIndex = IndexOf(mMeasurementUtility.Units, DistanceUnit.Meter);
            else if (MeasurementType == MeasurementType.Angular)
                defaultIndex = IndexOf(mMeasurementUtility.Units, AngularUnit.Mil);
            else if (MeasurementType == MeasurementType.Weight)
                defaultIndex = IndexOf(mMeasurementUtility.Units, WeightUnit.Gram);
            else if (MeasurementType == MeasurementType.Pressure)
                defaultIndex = IndexOf(mMeasurementUtility.Units, PressureUnit.Bar);
            else if (MeasurementType == MeasurementType.Temperature)
                defaultIndex = IndexOf(mMeasurementUtility.Units, TemperatureUnit.Celsius);
            else if (MeasurementType == MeasurementType.Velocity)
                defaultIndex = IndexOf(mMeasurementUtility.Units, VelocityUnit.MetersPerSecond);
            else if (MeasurementType == MeasurementType.Volume)
                defaultIndex = IndexOf(mMeasurementUtility.Units, VolumeUnit.Liter);
            else
                defaultIndex = 0;

            return mMeasurementUtility.Units;
        }

        private static int IndexOf<T>(IReadOnlyList<MeasurementUtility.Unit> units, T value)
            where T : Enum
        {
            for (int i = 0; i < units.Count; i++)
                if (units[i].Value.Equals(value))
                    return i;
            return 0;
        }

        public CultureInfo Culture { get; set; } = CultureInfo.CurrentUICulture;

        public double ParseNumericPart(string text)
        {
            if (text.Length == 0)
                return 0;
            else
                return double.Parse(text, Culture);
        }

        public string FormatNumericPart(double v)
        {
            var s1 = v.ToString("#,0.##", Culture);
            var s2 = v.ToString(Culture);

            var ds = Culture.NumberFormat.NumberDecimalSeparator;

            var i1 = s1.IndexOf(ds);
            var i2 = s2.IndexOf(ds);

            if (i1 <= 0 && i2 <= 0)
                return s1;

            StringBuilder sb = new StringBuilder();

            if (i1 >= 0)
                sb.Append(s1, 0, i1);
            else
                sb.Append(s1);

            if (i2 >= 0)
            {
                sb.Append(ds);
                sb.Append(s2, i2 + 1, s2.Length - (i2 + 1));
            }

            return sb.ToString();
        }

        public object Value(string text, object unit)
        {
            double v = ParseNumericPart(text);

            object u = ((MeasurementUtility.Unit)unit).Value;
            return mMeasurementUtility.Activator(v, u);
        }

        public MeasurementUtility.Unit GetUnit(object unit) => mMeasurementUtility.Units.First(v => v.Value.Equals(unit));

        public void ParseValue(object value, out string text, out MeasurementUtility.Unit unit)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            ValidateValueType(value.GetType());

            text = FormatNumericPart(mMeasurementUtility.ValueGetter(value));
            unit = GetUnit(mMeasurementUtility.UnitGetter(value));
        }

        public void ParseValue(string value, out string text, out MeasurementUtility.Unit unit) => ParseValue(mMeasurementUtility.Parser(value), out text, out unit);

        public void ValidateUnitType(Type unitType)
        {
            if (unitType != mMeasurementUtility.MeasurementUnit)
                throw new ArgumentException($"The unit type specified is {unitType.Name} while the unit type expected is {mMeasurementUtility.MeasurementUnit.Name}", nameof(unitType));
        }

        public void ValidateUnitType<T>() => ValidateUnitType(typeof(T));

        public void ValidateValueType(Type valueType)
        {
            if (valueType != mMeasurementUtility.MeasurementType)
                throw new ArgumentException($"The value specified is {valueType.Name} while the unit type expected is {mMeasurementUtility.MeasurementType.Name}", nameof(valueType));
        }

        public void ValidateValueType<T>() => ValidateValueType(typeof(T));

        public bool AllowKeyInEditor(string text, int selectionStart, int selectionLength, char character)
        {
            int position = selectionStart + selectionLength;
            string beforeSelect = text.Substring(0, selectionStart);
            string afterSelect = position < text.Length ? text.Substring(position) : "";

            if (character == '+' || character == '-')
            {
                if (text.Length == 0)
                    return true;

                if (selectionStart == 0 &&
                    !afterSelect.Any(c => c == '+' || c == '-'))
                    return true;
            }
            else if (character >= '0' && character <= '9')
            {
                if (afterSelect.Length == 0 || !afterSelect.Any(c => c == '+' || c == '-'))
                    return true;
            }
            else if (character == Culture.NumberFormat.NumberDecimalSeparator[0])
            {
                if (position > 0 &&
                    beforeSelect.Any(c => c >= '0' && c <= '9') &&
                    !beforeSelect.Contains(Culture.NumberFormat.NumberDecimalSeparator[0]) &&
                    !afterSelect.Contains(Culture.NumberFormat.NumberDecimalSeparator[0]))
                    return true;
            }
            else if (character == Culture.NumberFormat.NumberGroupSeparator[0])
            {
                if (position > 0 &&
                    beforeSelect.Any(c => c >= '0' && c <= '9') &&
                    !beforeSelect.Contains(Culture.NumberFormat.NumberDecimalSeparator[0]) &&
                    !beforeSelect.EndsWith(Culture.NumberFormat.NumberGroupSeparator[0]) &&
                    !afterSelect.Any(c => c == '+' || c == '-'))
                    return true;
            }
            return false;
        }

        public string DoIncrement(string numericPart, int direction)
        {
            double v = ParseNumericPart(numericPart);
            if (direction > 0 && v < Maximum)
                v += Increment;
            else if (direction < 0 && v > Minimum)
                    v -= Increment;
            return FormatNumericPart(v);
        }
    }
}