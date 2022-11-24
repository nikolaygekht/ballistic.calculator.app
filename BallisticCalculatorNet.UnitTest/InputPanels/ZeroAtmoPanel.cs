using BallisticCalculator;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.InputPanels;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using Gehtsoft.Measurements;
using Gehtsoft.Winforms.FluentAssertions;
using System;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.InputPanels
{
    public class ZeroAtmoPanel
    {
        [Fact]
        public void Initial()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<ZeroAtmosphereControl>(5, 5, 100, 100);

            control.CheckBox("checkBoxOther").Should().BeNotChecked();
            control.Control("atmosphereControl").Should().BeDisabled();
            control.Atmosphere.Should().BeNull();
        }

        [Fact]
        public void Metric()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<ZeroAtmosphereControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Metric;

            control.Control("atmosphereControl")
                .MeasurementControl("measurementAltitude")
                .Should().HaveUnitSelected(DistanceUnit.Meter);
        }

        [Fact]
        public void Imperial()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<ZeroAtmosphereControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Imperial;

            control.Control("atmosphereControl")
                .MeasurementControl("measurementAltitude")
                .Should().HaveUnitSelected(DistanceUnit.Foot);
        }

        [Fact]
        public void EnableDisable()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<ZeroAtmosphereControl>(5, 5, 100, 100);

            control.CheckBox("checkBoxOther").Checked = true;
            control.InvokeEventHandler("checkBoxOther_CheckedChanged", EventArgs.Empty);
            var atmoControl = control.Control("atmosphereControl").As<AtmosphereControl>();
            atmoControl.Should().BeEnabled();
            control.Atmosphere.Should().NotBeNull();

            control.CheckBox("checkBoxOther").Checked = false;
            control.InvokeEventHandler("checkBoxOther_CheckedChanged", EventArgs.Empty);
            atmoControl.Should().BeDisabled();
            control.Atmosphere.Should().BeNull();
        }

        [Fact]
        public void NoValue()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<ZeroAtmosphereControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Metric;
            control.Atmosphere = null;

            control.CheckBox("checkBoxOther").Should().BeNotChecked();
            control.Control("atmosphereControl").Should().BeDisabled();

            control.Atmosphere.Should().BeNull();
        }

        [Fact]
        public void Value()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<ZeroAtmosphereControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Metric;
            control.Atmosphere = new Atmosphere(300.As(DistanceUnit.Meter), 1.01.As(PressureUnit.Bar), 15.As(TemperatureUnit.Celsius), 0.78);

            control.CheckBox("checkBoxOther").Should().BeChecked();
            control.Control("atmosphereControl").Should().BeEnabled();
            control.Control("atmosphereControl")
                .MeasurementControl("measurementAltitude")
                .ValueAsMeasurement<DistanceUnit>().Should().Be(300.As(DistanceUnit.Meter));

            control.Atmosphere.Altitude.Should().Be(300.As(DistanceUnit.Meter));
        }
    }
}
