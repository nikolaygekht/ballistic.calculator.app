using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculatorNet.MeasurementControl;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using FluentAssertions.Common;
using Gehtsoft.Measurements;
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

            control.UnitPartControl.Should().NotBeNull();
            control.UnitPartControl.Should().BeOfType(typeof(ComboBox));

            control.NumericPartControl.Should().NotBeNull();
            control.NumericPartControl.Should().BeOfType(typeof(TextBox));

            control.MeasurementType.Should().Be(MeasurementType.Distance);

            control.Minimum.Should().Be(-10000);
            control.Maximum.Should().Be(10000);
            control.Increment.Should().Be(1);

            control.Culture.Should().Be(CultureInfo.CurrentUICulture);

            control.Value.Should().BeOfType(typeof(Measurement<DistanceUnit>));
            control.Value.Should().Be(DistanceUnit.Line.New(0));
            control.ValueAs<DistanceUnit>().Should().NotBeNull();
            control.ValueAs<DistanceUnit>().Value.Should().Be(0);

            control.Unit.Should().Be(DistanceUnit.Line);
        }

        [Theory]
        [InlineData(1.2345, "1.2345", DistanceUnit.Inch)]
        [InlineData(-1.23, "-1.23", DistanceUnit.Centimeter)]
        [InlineData(1234.5, "1,234.5", DistanceUnit.Meter)]
        [InlineData(1234567.89012345, "1,234,567.89012345", DistanceUnit.Millimeter)]
        public void AssignValue(double value, string expectedText, DistanceUnit unit)
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<MeasurementControl.MeasurementControl>(13, 13, 300, 28);
            control.Value = new Measurement<DistanceUnit>(value, unit);
            control.ForceCulture(CultureInfo.InvariantCulture);

            control.Value.Should().Be(new Measurement<DistanceUnit>(value, unit));
            control.NumericPartControl.Text.Should().Be(expectedText);
            control.Unit.Should().Be(unit);
        }

        [Theory]
        [InlineData(MeasurementType.Distance, typeof(DistanceUnit))]
        [InlineData(MeasurementType.Angular, typeof(AngularUnit))]
        [InlineData(MeasurementType.Pressure, typeof(PressureUnit))]
        [InlineData(MeasurementType.Velocity, typeof(VelocityUnit))]
        public void Units(MeasurementType type, Type unitType)
        {
            using TestForm tf = new TestForm();
            var util = MeasurementTools.Instance.GetUtility(type);

            var control = tf.AddControl<MeasurementControl.MeasurementControl>(13, 13, 300, 28);
            if (control.MeasurementType != type)
                control.MeasurementType = type;

            control.Unit.Should().BeOfType(unitType);
            control.Value.Should().BeOfType(typeof(Measurement<>).MakeGenericType(new Type[] { unitType }));

            control.UnitPartControl.Items.Should().HaveCount(util.Units.Count);
            control.UnitPartControl.Items.Should().HaveCount(Enum.GetValues(unitType).Length);
            foreach (var unit in util.Units)
                control.UnitPartControl.Items.Should().Contain(unit);

            
        }


    }
}
