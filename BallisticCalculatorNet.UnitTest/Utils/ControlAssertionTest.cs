using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;
using FluentAssertions;
using Xunit.Sdk;
using BallisticCalculatorNet.MeasurementControl;
using Gehtsoft.Measurements;
using Gehtsoft.Winforms.FluentAssertions;

namespace BallisticCalculatorNet.UnitTest.Utils
{
    public class ControlAssertionTest
    {
        [Fact]
        public void Measurement_HaveValue_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Distance;
            c.Value = DistanceUnit.Meter.New(1.5);
            ((Action)(() => c.Should().HaveValue(DistanceUnit.Meter.New(1.5)))).Should().NotThrow();
            ((Action)(() => c.Should().HaveValue(DistanceUnit.Centimeter.New(150)))).Should().NotThrow();
        }

        [Fact]
        public void Measurement_HaveExactValue_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Distance;
            c.Value = DistanceUnit.Meter.New(1.5);
            ((Action)(() => c.Should().HaveExactValue(DistanceUnit.Meter.New(1.5)))).Should().NotThrow();
        }
        [Fact]
        public void Measurement_HaveExactValue_Fail()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Distance;
            c.Value = DistanceUnit.Meter.New(1.5);
            ((Action)(() => c.Should().HaveExactValue(DistanceUnit.Centimeter.New(150)))).Should().Throw<XunitException>();
        }

        [Fact]
        public void Measurement_HaveValue_Fail_Value()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Distance;
            c.Value = DistanceUnit.Meter.New(1.5);
            ((Action)(() => c.Should().HaveValue(DistanceUnit.Meter.New(1.6)))).Should().Throw<XunitException>();
        }

        [Fact]
        public void Measurement_HaveValue_Fail_Type()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Distance;
            c.Value = DistanceUnit.Meter.New(1.5);
            ((Action)(() => c.Should().HaveValue(AngularUnit.CmPer100Meters.New(1.6)))).Should().Throw<XunitException>();
        }

        [Fact]
        public void Measurement_HaveUnitType_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Distance;
            ((Action)(() => c.Should().HaveUnitType(MeasurementType.Distance))).Should().NotThrow();
        }

        [Fact]
        public void Measurement_HaveUnitType_Fail()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Angular;
            ((Action)(() => c.Should().HaveUnitType(MeasurementType.Distance))).Should().Throw<XunitException>();
        }

        [Fact]
        public void Measurement_HaveUnitSelected_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Distance;
            c.Value = DistanceUnit.Meter.New(1.5);
            ((Action)(() => c.Should().HaveUnitSelected(DistanceUnit.Meter))).Should().NotThrow();
        }

        [Fact]
        public void Measurement_HaveUnitSelected_Fail()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Distance;
            c.Value = DistanceUnit.Meter.New(1.5);
            ((Action)(() => c.Should().HaveUnitSelected(DistanceUnit.Centimeter))).Should().Throw<XunitException>();
        }
    }
}
