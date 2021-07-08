using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculator;
using BallisticCalculatorNet.MeasurementControl;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using FluentAssertions.Common;
using Gehtsoft.Measurements;
using Gehtsoft.Winforms.FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.MsrmentControl
{
    public class ControlTest
    {
        [Fact]
        public void InitialStatus()
        {
            using TestForm tf = new TestForm();

            var control = tf.AddControl<MeasurementControl.MeasurementControl>(13, 13, 300, 28);
            control.Control<Control>("UnitPart").Should()
                .Exist()
                .And
                .BeOfType<ComboBox>();

            control.Control<Control>("NumericPart").Should()
                .Exist()
                .And
                .BeOfType<TextBox>();

            control.MeasurementType.Should().Be(MeasurementType.Distance);

            control.Minimum.Should().Be(-10000);
            control.Maximum.Should().Be(10000);
            control.Increment.Should().Be(1);

            control.Value.Should().BeOfType(typeof(Measurement<DistanceUnit>));
            control.Value.Should().Be(DistanceUnit.Line.New(0));
            control.ValueAsMeasurement<DistanceUnit>().Should().NotBeNull();
            control.ValueAsMeasurement<DistanceUnit>().Value.Should().Be(0);

            control.Unit.Should().Be(DistanceUnit.Meter);
        }

        [Theory]
        [InlineData(1.2345, "1.2345", DistanceUnit.Inch)]
        [InlineData(-1.23, "-1.23", DistanceUnit.Centimeter)]
        [InlineData(1234.5, "1,234.5", DistanceUnit.Meter)]
        [InlineData(1234567.89012345, "1,234,567.89012345", DistanceUnit.Millimeter)]
        public void AssignAndGetValue(double value, string expectedText, DistanceUnit unit)
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<MeasurementControl.MeasurementControl>(13, 13, 300, 28);
            control.ForceCulture(CultureInfo.InvariantCulture);
            control.Value = new Measurement<DistanceUnit>(value, unit);

            control.Value.Should().Be(new Measurement<DistanceUnit>(value, unit));
            control.TextBox("NumericPart").Should().HaveText(expectedText);
            control.Unit.Should().Be(unit);
        }

        [Theory]
        [InlineData(1.23456, null, "1.23456")]
        [InlineData(1.23456, 3, "1.235")]
        [InlineData(1987.23456, 3, "1,987.235")]

        public void DigitalPoints(double value, int? decimalPoints, string text)
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<MeasurementControl.MeasurementControl>(13, 13, 300, 28);
            control.DecimalPoints = decimalPoints;
            control.MeasurementType = MeasurementType.Distance;
            control.Value = DistanceUnit.Meter.New(value);
            control.TextBox("NumericPart").Text.Should().Be(text);
        }

        [Fact]
        public void ReturnOriginalValueIfNotChanged()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<MeasurementControl.MeasurementControl>(13, 13, 300, 28);
            control.DecimalPoints = 1;
            control.MeasurementType = MeasurementType.Distance;
            control.Value = DistanceUnit.Meter.New(1.2345);
            control.TextBox("NumericPart").Text.Should().Be("1.2");
            control.Value.Should().Be(DistanceUnit.Meter.New(1.2345));
        }

        [Theory]
        [InlineData(MeasurementType.Distance, typeof(DistanceUnit))]
        [InlineData(MeasurementType.Angular, typeof(AngularUnit))]
        [InlineData(MeasurementType.Pressure, typeof(PressureUnit))]
        [InlineData(MeasurementType.Velocity, typeof(VelocityUnit))]
        [InlineData(MeasurementType.Temperature, typeof(TemperatureUnit))]
        [InlineData(MeasurementType.Volume, typeof(VolumeUnit))]
        [InlineData(MeasurementType.BallisticCoefficient, typeof(DragTableId))]
        public void Units(MeasurementType type, Type unitType)
        {
            using TestForm tf = new TestForm();
            var util = MeasurementTools.Instance.GetUtility(type);
            var control = tf.AddControl<MeasurementControl.MeasurementControl>(13, 13, 300, 28);
            if (control.MeasurementType != type)
                control.MeasurementType = type;

            control.Unit.Should().BeOfType(unitType);
            if (control.MeasurementType == MeasurementType.BallisticCoefficient)
                control.Value.Should().BeOfType(typeof(BallisticCoefficient));
            else
                control.Value.Should().BeOfType(typeof(Measurement<>).MakeGenericType(new Type[] { unitType }));

            var unitPart = control.ComboBox("UnitPart");

            unitPart.Should()
                .HaveItemsCount(util.Units.Count)
                .And
                .HaveItemsCount(Enum.GetValues(unitType).Length);

            foreach (MeasurementUtility.Unit unit in util.Units)
                unitPart.Should().HaveItemMatching<MeasurementUtility.Unit>(u => u.Equals(unit));
        }

        [Fact]
        public void ForceCulture()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<MeasurementControl.MeasurementControl>(13, 13, 300, 28);
            control.MeasurementType = MeasurementType.Angular;
            control.ForceCulture(CultureInfo.InvariantCulture);
            var numericPart = control.TextBox("NumericPart");

            numericPart.Should()
                .Exist()
                .And
                .HaveNoText();

            control.Value = new Measurement<AngularUnit>(1234.56, AngularUnit.Degree);
            numericPart.Should().HaveText("1,234.56");

            var ruCulture = CultureInfo.GetCultureInfo("ru-RU");
            var expectRuValue = "1" + ruCulture.NumberFormat.NumberGroupSeparator + "234" + ruCulture.NumberFormat.NumberDecimalSeparator + "56";
            control.ForceCulture(ruCulture);
            numericPart.Should().HaveText(expectRuValue);
        }

        [Theory]
        [InlineData("", 1, 1, "1")]
        [InlineData("0", 1, 1, "1")]
        [InlineData("", 1, -1, "-1")]
        [InlineData("0", 1, -1, "-1")]
        [InlineData("4.5", 1, 1, "5.5")]
        [InlineData("4.5", 1, -1, "3.5")]
        [InlineData("4.5", 0.5, 1, "5")]
        [InlineData("4.5", 0.5, -1, "4")]
        [InlineData("4.5", 0.01, 1, "4.51")]
        [InlineData("4.5", 0.01, -1, "4.49")]
        public void Increment(string initialValue, double increment, int direction, string expectedValue)
        {
            MeasurmentControlController controller = new MeasurmentControlController
            {
                Increment = increment,
                Culture = CultureInfo.InvariantCulture
            };

            controller.DoIncrement(initialValue, direction).Should().Be(expectedValue);
        }

        [Theory]
        //allowed characters
        //any numbers during empty, before numbers and after numbers
        [InlineData("", 0, 0, '0', true)]
        [InlineData("", 0, 0, '1', true)]
        [InlineData("", 0, 0, '2', true)]
        [InlineData("", 0, 0, '3', true)]
        [InlineData("", 0, 0, '4', true)]
        [InlineData("", 0, 0, '5', true)]
        [InlineData("", 0, 0, '6', true)]
        [InlineData("", 0, 0, '7', true)]
        [InlineData("", 0, 0, '8', true)]
        [InlineData("", 0, 0, '9', true)]
        [InlineData("0", 0, 0, '0', true)]
        [InlineData("0", 1, 0, '0', true)]
        //+ and - in empty lines and in front of number
        [InlineData("", 0, 0, '+', true)]
        [InlineData("", 0, 0, '-', true)]
        [InlineData("1", 0, 0, '+', true)]
        [InlineData("1", 0, 0, '-', true)]
        //...and when we replace sign
        [InlineData("+1", 0, 1, '-', true)]
        //. (decimal separators) anywhere when there are numbers before 
        [InlineData("1", 1, 0, '.', true)]
        [InlineData("11", 1, 0, '.', true)]
        [InlineData("11", 2, 0, '.', true)]
        //... and when we replace .
        [InlineData("11.1", 2, 1, '.', true)]
        //, (group separator) at the end of the text or when there is numbers before
        [InlineData("1", 1, 0, ',', true)]
        [InlineData("11", 1, 0, ',', true)]
        [InlineData("11", 2, 0, ',', true)]
        [InlineData("1234", 2, 0, ',', true)]
        [InlineData("1,234", 5, 0, ',', true)]
        //not allowed characters
        //non-digits anywhere
        [InlineData("", 0, 0, '/', false)]
        [InlineData("0", 0, 0, '/', false)]
        [InlineData("0", 1, 0, '/', false)]
        [InlineData("", 0, 0, 'a', false)]
        [InlineData("", 0, 0, 'б', false)]
        //+ and - if they already appeared before or after
        [InlineData("+1", 0, 0, '-', false)]
        [InlineData("-1", 0, 0, '-', false)]
        [InlineData("-1", 1, 0, '-', false)]
        [InlineData("+1", 2, 0, '-', false)]
        [InlineData("-1", 2, 0, '-', false)]
        [InlineData("+1", 0, 0, '+', false)]
        [InlineData("-1", 0, 0, '+', false)]
        [InlineData("-1", 1, 0, '+', false)]
        [InlineData("+1", 2, 0, '+', false)]
        [InlineData("-1", 2, 0, '+', false)]
        //+ and - not in first position
        [InlineData("11", 1, 0, '-', false)]
        [InlineData("11", 2, 0, '-', false)]
        [InlineData("11", 1, 0, '+', false)]
        [InlineData("11", 2, 0, '+', false)]
        //. (decimal separator) if there is no numbers before
        [InlineData("+1", 0, 0, '.', false)]
        [InlineData("+1", 1, 0, '.', false)]
        [InlineData("1", 0, 0, '.', false)]
        //, (group separator) if there is no numbers before 
        [InlineData("", 0, 0, ',', false)]
        [InlineData("1", 0, 0, ',', false)]
        [InlineData("+", 1, 0, ',', false)]
        //of where is a decimal point before
        [InlineData("1.2", 2, 0, ',', false)]
        [InlineData("1.2", 3, 0, ',', false)]
        //and not following another separator
        [InlineData("1,", 2, 0, ',', false)]
        [InlineData("1,2", 2, 0, ',', false)]
        public void AllowKeyInEditor(string text, int position, int length, char c, bool expected)
        {
            MeasurmentControlController controller = new MeasurmentControlController
            {
                Culture = CultureInfo.InvariantCulture
            };

            controller.AllowKeyInEditor(text, position, length, c).Should().Be(expected);
        }

        [Theory]
        [InlineData(1000, 1)]
        [InlineData(1000, 0.1)]
        [InlineData(0, 1)]
        public void TestMaximum(double maximum, double increment)
        {
            MeasurmentControlController controller = new MeasurmentControlController
            {
                Culture = CultureInfo.InvariantCulture,
                Maximum = maximum,
                Increment = increment,
            };

            var s = controller.FormatNumericPart(maximum);
            controller.DoIncrement(s, 1).Should().Be(s);
        }

        [Theory]
        [InlineData(1000, 1)]
        [InlineData(1000, 0.1)]
        [InlineData(-1000, 1)]
        [InlineData(-1000, 0.1)]
        [InlineData(0, 1)]
        public void TestMinimum(double minimum, double increment)
        {
            MeasurmentControlController controller = new MeasurmentControlController
            {
                Culture = CultureInfo.InvariantCulture,
                Minimum = minimum,
                Increment = increment,
            };

            var s = controller.FormatNumericPart(minimum);
            controller.DoIncrement(s, -1).Should().Be(s);
        }

        [Theory]
        [InlineData(MeasurementType.Distance, 4, 10, DistanceUnit.Meter, 32.8084, DistanceUnit.Foot)]
        [InlineData(MeasurementType.Velocity, 2, 5.5, VelocityUnit.FeetPerSecond, 3.75, VelocityUnit.MilesPerHour)]
        [InlineData(MeasurementType.Velocity, 2, 3.75, VelocityUnit.MilesPerHour, 5.5, VelocityUnit.FeetPerSecond)]
        public void ChangeUnit<T>(MeasurementType type, int accurracy, double initialValue, T initialUnit, double convertedValue, T targetUnit)
            where T : Enum
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<MeasurementControl.MeasurementControl>(13, 13, 300, 28);
            control.MeasurementType = type;
            control.Value = new Measurement<T>(initialValue, initialUnit);
            control.ChangeUnit(targetUnit, accurracy);
            control.UnitAs<T>().Should().Be(targetUnit);
            control.TextBox("NumericPart").Text.Should().Be(convertedValue.ToString());
            //change back to initial value
            control.ChangeUnit(initialUnit, null);
            control.Value.Should().Be(new Measurement<T>(initialValue, initialUnit));
        }

        [Theory]
        [InlineData(MeasurementType.Distance, "10.5m", 10.5, DistanceUnit.Meter)]
        [InlineData(MeasurementType.Distance, "1.234", 1.234, DistanceUnit.Meter)]
        [InlineData(MeasurementType.Distance, "1.234in", 1.234, DistanceUnit.Inch)]
        public void SetTextValue<T>(MeasurementType type, string text, double value, T unit)
            where T : Enum
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<MeasurementControl.MeasurementControl>(13, 13, 300, 28);
            control.MeasurementType = type;
            control.TextValue = text;

            (control.ComboBox("UnitPart").SelectedItem as MeasurementUtility.Unit)?.Value.Should().Be(unit);
            control.TextBox("NumericPart").Text.Should().Be(value.ToString());
            control.Value.Should().Be(unit.New(value));
        }

        [Theory]
        [InlineData(3, 0.365, DragTableId.G1, "0.365")]
        [InlineData(3, 0.3651, DragTableId.G1, "0.365")]
        [InlineData(3, 0.225, DragTableId.G7, "0.225")]
        public void BallisticCoefficient(int accuracy, double value, DragTableId table, string textValue)
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<MeasurementControl.MeasurementControl>(13, 13, 300, 28);
            control.MeasurementType = MeasurementType.BallisticCoefficient;
            control.DecimalPoints = accuracy;

            control.Value = new BallisticCoefficient(value, table);
            control.TextValue.Should().Be(textValue + table.ToString());

            control.Value = new BallisticCoefficient(1, DragTableId.G1);
            control.TextValue.Should().Be("1G1");

            control.TextValue = textValue + table.ToString();
            control.ValueAs<BallisticCoefficient>().Should().Be(new BallisticCoefficient(double.Parse(textValue), table));
        }
    }
}
