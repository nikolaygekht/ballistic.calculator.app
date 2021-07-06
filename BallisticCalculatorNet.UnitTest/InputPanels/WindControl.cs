using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BallisticCalculator;
using BallisticCalculatorNet.InputPanels;
using BallisticCalculatorNet.MeasurementControl;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using Gehtsoft.Measurements;
using Gehtsoft.Winforms.FluentAssertions;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.InputPanels
{
    public class WindPanel
    {
        [Fact]
        public void InitalStatus()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<WindControl>(5, 5, 100, 100);

            control.CheckBox("checkBoxDistance")
                .Should().Exist()
                .And.BeNotChecked();

            control.MeasurementControl("measurementDistance")
                .Should().Exist()
                .And.HaveUnitType(MeasurementType.Distance)
                .And.HaveUnitSelected(DistanceUnit.Meter)
                .And.HaveValue(DistanceUnit.Meter.New(0));

            control.MeasurementControl("measurementDirection")
                .Should().Exist()
                .And.HaveUnitType(MeasurementType.Angular)
                .And.HaveUnitSelected(AngularUnit.Degree)
                .And.HaveValue(AngularUnit.Degree.New(0));

            control.MeasurementControl("measurementVelocity")
                .Should().Exist()
                .And.HaveUnitType(MeasurementType.Velocity)
                .And.HaveUnitSelected(VelocityUnit.MetersPerSecond)
                .And.HaveValue(VelocityUnit.MetersPerSecond.New(0));
        }

        [Fact]
        public void SetNullWind()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<WindControl>(5, 5, 100, 100);

            control.Wind = null;

            control.CheckBox("checkBoxDistance")
                .Should().Exist()
                .And.BeNotChecked();

            control.MeasurementControl("measurementDistance")
                .Should().Exist()
                .And.HaveUnitType(MeasurementType.Distance)
                .And.HaveUnitSelected(DistanceUnit.Meter)
                .And.HaveValue(DistanceUnit.Meter.New(0));

            control.MeasurementControl("measurementDirection")
                .Should().Exist()
                .And.HaveUnitType(MeasurementType.Angular)
                .And.HaveUnitSelected(AngularUnit.Degree)
                .And.HaveValue(AngularUnit.Degree.New(0));

            control.MeasurementControl("measurementVelocity")
                .Should().Exist()
                .And.HaveUnitType(MeasurementType.Velocity)
                .And.HaveUnitSelected(VelocityUnit.MetersPerSecond)
                .And.HaveValue(VelocityUnit.MetersPerSecond.New(0));

            control.Wind.Should().BeNull();
        }

        private Wind CreateWind(double? distance, DistanceUnit? distanceUnit, double direction, AngularUnit directionUnit, double velocity, VelocityUnit velocityUnit)
        {
            Wind w = new Wind();

            if (distance == null || distanceUnit == null)
                w.MaximumRange = null;
            else
                w.MaximumRange = new Measurement<DistanceUnit>(distance.Value, distanceUnit.Value);

            w.Direction = new Measurement<AngularUnit>(direction, directionUnit);
            w.Velocity = new Measurement<VelocityUnit>(velocity, velocityUnit);

            return w;
        }

        [Theory]
        [InlineData(null, null, 2, AngularUnit.Degree, 3, VelocityUnit.FeetPerSecond)]
        [InlineData(1, DistanceUnit.Foot, 2, AngularUnit.Degree, 3, VelocityUnit.FeetPerSecond)]
        [InlineData(1.23, DistanceUnit.Mile, 2.45, AngularUnit.Mil, 3.67, VelocityUnit.MilesPerHour)]
        public void SetValue(double? distance, DistanceUnit? distanceUnit, double direction, AngularUnit directionUnit, double velocity, VelocityUnit velocityUnit)
        {
            var w = CreateWind(distance, distanceUnit, direction, directionUnit, velocity, velocityUnit);

            using TestForm tf = new TestForm();
            var control = tf.AddControl<WindControl>(5, 5, 100, 100);

            control.Wind = w;

            if (w.MaximumRange == null)
            {
                control.CheckBox("checkBoxDistance").Should().BeNotChecked();
                control.MeasurementControl("measurementDistance")
                    .Should().HaveExactValue(DistanceUnit.Meter.New(0))
                    .And.BeEnabled(false);
            }
            else
            {
                control.CheckBox("checkBoxDistance").Should().BeChecked();
                control.MeasurementControl("measurementDistance")
                    .Should().HaveExactValue(w.MaximumRange.Value)
                    .And.BeEnabled(true);
            }
           

            control.MeasurementControl("measurementDirection")
                .Should().HaveExactValue(w.Direction);

            control.MeasurementControl("measurementVelocity")
                .Should().HaveExactValue(w.Velocity);

            var w1 = control.Wind;
            w1.Should().NotBeSameAs(w);

            w1.MaximumRange.Should().Be(w.MaximumRange);
            w1.Direction.Should().Be(w.Direction);
            w1.Velocity.Should().Be(w.Velocity);
        }

        [Theory]
        [InlineData(null, null, 2, AngularUnit.Degree, 3, VelocityUnit.FeetPerSecond)]
        [InlineData(1, DistanceUnit.Foot, 2, AngularUnit.Degree, 3, VelocityUnit.FeetPerSecond)]
        [InlineData(1.23, DistanceUnit.Mile, 2.45, AngularUnit.Mil, 3.67, VelocityUnit.MilesPerHour)]
        public void GetValue(double? distance, DistanceUnit? distanceUnit, double direction, AngularUnit directionUnit, double velocity, VelocityUnit velocityUnit)
        {
            var w = CreateWind(distance, distanceUnit, direction, directionUnit, velocity, velocityUnit);

            using TestForm tf = new TestForm();
            var control = tf.AddControl<WindControl>(5, 5, 100, 100);

            if (w.MaximumRange != null)
            {
                control.CheckBox("checkBoxDistance").Checked = true;
                control.MeasurementControl("measurementDistance").Value = w.MaximumRange;
            }
            control.MeasurementControl("measurementDirection").Value = w.Direction;
            control.MeasurementControl("measurementVelocity").Value = w.Velocity;

            var w1 = control.Wind;
 
            w1.MaximumRange.Should().Be(w.MaximumRange);
            w1.Direction.Should().Be(w.Direction);
            w1.Velocity.Should().Be(w.Velocity);
        }

    }
}
