using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BallisticCalculator;
using BallisticCalculatorNet.Api;
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

        private static Wind CreateWind(double? distance, DistanceUnit? distanceUnit, double direction, AngularUnit directionUnit, double velocity, VelocityUnit velocityUnit)
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
        [InlineData(null, null, 2.0, AngularUnit.Degree, 3.0, VelocityUnit.FeetPerSecond)]
        [InlineData(1.0, DistanceUnit.Foot, 2.0, AngularUnit.Degree, 3.0, VelocityUnit.FeetPerSecond)]
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
        [InlineData(null, null, 2.0, AngularUnit.Degree, 3.0, VelocityUnit.FeetPerSecond)]
        [InlineData(1.0, DistanceUnit.Foot, 2.0, AngularUnit.Degree, 3.0, VelocityUnit.FeetPerSecond)]
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

    public class MultiWindPanel
    {
        [Fact]
        public void Initial()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<MultiWindControl>(5, 5, 100, 100);
            control.Controls<WindControl>().Should().HaveCount(1);
            control.Control("buttonAdd").Should().Exist().And.BeEnabled();
            control.Control("buttonClear").Should().Exist().And.BeEnabled();
        }

        private static WindCollection CreateTestCollection()
        {
            var collection = new WindCollection
            {
                new Wind(10.As(VelocityUnit.MetersPerSecond), 90.As(AngularUnit.Degree), 0.As(DistanceUnit.Meter)),
                new Wind(11.As(VelocityUnit.MetersPerSecond), 91.As(AngularUnit.Degree), 250.As(DistanceUnit.Meter)),
                new Wind(12.As(VelocityUnit.MetersPerSecond), -92.As(AngularUnit.Degree), 500.As(DistanceUnit.Meter))
            };
            return collection;
        }

        private static bool WindsAreEqual(Wind w1, Wind w2)
        {
            if (w1.MaximumRange != null && w2.MaximumRange == null ||
                w1.MaximumRange == null && w2.MaximumRange != null)
                return false;

            return ((w1.MaximumRange == null && w2.MaximumRange == null) ||
                     w1.MaximumRange == w2.MaximumRange) &&
                    w1.Direction == w2.Direction &&
                    w1.Velocity == w2.Velocity;
        }

        [Fact]
        public void InitializeWithNull()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<MultiWindControl>(5, 5, 100, 100);
            control.Winds = null;
            control.Controls<WindControl>().Should().HaveCount(1);
            control.Control<WindControl>("windControl1").IsEmpty().Should().BeTrue();
            control.Control("buttonAdd").Should().Exist().And.BeEnabled();
            control.Control("buttonClear").Should().Exist().And.BeEnabled();
        }

        [Fact]
        public void InitializeWithEmpty()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<MultiWindControl>(5, 5, 100, 100);
            control.Winds = new WindCollection();
            control.Controls<WindControl>().Should().HaveCount(1);
            control.Control<WindControl>("windControl1").IsEmpty().Should().BeTrue();
            control.Control("buttonAdd").Should().Exist().And.BeEnabled();
            control.Control("buttonClear").Should().Exist().And.BeEnabled();
        }

        [Fact]
        public void InitializeWithList()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<MultiWindControl>(5, 5, 100, 100);
            var tc = CreateTestCollection(); 
            control.Winds = CreateTestCollection();

            control.Controls<WindControl>().Should().HaveCount(3);
            control.Control<WindControl>("windControl1").Wind.Should().Match<Wind>(w => WindsAreEqual(w, tc[0]));
            control.Control<WindControl>("windControl2").Wind.Should().Match<Wind>(w => WindsAreEqual(w, tc[1]));
            control.Control<WindControl>("windControl3").Wind.Should().Match<Wind>(w => WindsAreEqual(w, tc[2]));
        }

        [Fact]
        public void InitializeThenClear()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<MultiWindControl>(5, 5, 100, 100);
            control.Winds = CreateTestCollection();
            control.Controls<WindControl>().Should().HaveCount(3);

            control.InvokeEventHandler("buttonClear_Click", EventArgs.Empty);

            control.Controls<WindControl>().Should().HaveCount(1);
            control.Control<WindControl>("windControl1").IsEmpty().Should().BeTrue();
        }

        [Fact]
        public void AddByButton()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<MultiWindControl>(5, 5, 100, 100);
            var ts = CreateTestCollection(); 
            control.Winds = ts;
            control.Controls<WindControl>().Should().HaveCount(3);

            control.InvokeEventHandler("buttonAdd_Click", EventArgs.Empty);

            control.Controls<WindControl>().Should().HaveCount(4);
            control.Control<WindControl>("windControl4").IsEmpty().Should().BeFalse();
            var newWind = control.Control<WindControl>("windControl4").Wind;
            newWind.MaximumRange.Should().Be(ts[^1].MaximumRange.Value + 100.As(ts[^1].MaximumRange.Value.Unit));
            newWind.Velocity.Should().Be(ts[^1].Velocity);
            newWind.Direction.Should().Be(ts[^1].Direction);
        }

        [Fact]
        public void AddPositions()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<MultiWindControl>(5, 5, 100, 100);
            control.Winds = CreateTestCollection();

            control.InvokeEventHandler("buttonAdd_Click", EventArgs.Empty);
            control.InvokeEventHandler("buttonAdd_Click", EventArgs.Empty);
            control.InvokeEventHandler("buttonAdd_Click", EventArgs.Empty);

            var controls = control.Controls<WindControl>().ToArray();

            for (int i = 1; i < controls.Length; i++)
            {
                controls[i].Location.X.Should().Be(1);
                controls[i].Location.Y.Should().BeGreaterThan(controls[i - 1].Location.Y + controls[i - 1].Size.Height);
                controls[i].TabIndex.Should().BeGreaterThan(controls[i - 1].TabIndex);

                controls[i].Size.Height.Should().Be(controls[0].Size.Height);
                controls[i].Size.Width.Should().Be(controls[0].Size.Width);
            }
        }
    }
}
