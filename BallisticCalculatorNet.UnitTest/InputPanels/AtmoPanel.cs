using BallisticCalculator;
using BallisticCalculatorNet.InputPanels;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using Gehtsoft.Measurements;
using Gehtsoft.Winforms.FluentAssertions;
using System;
using System.Windows.Forms;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.InputPanels
{
    public class AtmoPanel
    {
        [Fact]
        public void Metric()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AtmosphereControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Metric;

            control.MeasurementControl("measurementAltitude").Should().HaveUnitSelected(DistanceUnit.Meter);
            control.MeasurementControl("measurementAltitude").DecimalPoints.Should().Be(0);
            control.MeasurementControl("measurementTemperature").Should().HaveUnitSelected(TemperatureUnit.Celsius);
            control.MeasurementControl("measurementTemperature").DecimalPoints.Should().Be(1);
            control.MeasurementControl("measurementPressure").Should().HaveUnitSelected(PressureUnit.MillimetersOfMercury);
            control.MeasurementControl("measurementPressure").DecimalPoints.Should().Be(1);

        }

        [Fact]
        public void Imperial()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AtmosphereControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Imperial;

            control.MeasurementControl("measurementAltitude").Should().HaveUnitSelected(DistanceUnit.Foot);
            control.MeasurementControl("measurementAltitude").DecimalPoints.Should().Be(0);
            control.MeasurementControl("measurementTemperature").Should().HaveUnitSelected(TemperatureUnit.Fahrenheit);
            control.MeasurementControl("measurementTemperature").DecimalPoints.Should().Be(1);
            control.MeasurementControl("measurementPressure").Should().HaveUnitSelected(PressureUnit.InchesOfMercury);
            control.MeasurementControl("measurementPressure").DecimalPoints.Should().Be(2);
        }

        [Fact]
        public void Metric_SetDefault()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AtmosphereControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Metric;
            control.InvokeEventHandler("buttonReset_Click", EventArgs.Empty);

            control.MeasurementControl("measurementAltitude").ValueAs<Measurement<DistanceUnit>>()
                .Should().Be(0.As(DistanceUnit.Meter));
            control.MeasurementControl("measurementAltitude").Should().HaveUnitSelected(DistanceUnit.Meter);

            control.MeasurementControl("measurementTemperature").ValueAs<Measurement<TemperatureUnit>>()
                .Should().Be(15.As(TemperatureUnit.Celsius));
            control.MeasurementControl("measurementTemperature").Should().HaveUnitSelected(TemperatureUnit.Celsius);

            control.MeasurementControl("measurementPressure").ValueAs<Measurement<PressureUnit>>()
                .Should().Be(760.As(PressureUnit.MillimetersOfMercury));
            control.MeasurementControl("measurementPressure").Should().HaveUnitSelected(PressureUnit.MillimetersOfMercury);

            control.TextBox("textBoxHumidity").Should().HaveText("78");
        }

        [Fact]
        public void Imperial_SetDefault()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AtmosphereControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Imperial;
            control.Atmosphere = null;

            control.MeasurementControl("measurementAltitude").ValueAs<Measurement<DistanceUnit>>()
                .Should().Be(0.As(DistanceUnit.Foot));
            control.MeasurementControl("measurementAltitude").Should().HaveUnitSelected(DistanceUnit.Foot);

            control.MeasurementControl("measurementTemperature").ValueAs<Measurement<TemperatureUnit>>()
                .Should().Be(59.As(TemperatureUnit.Fahrenheit));
            control.MeasurementControl("measurementTemperature").Should().HaveUnitSelected(TemperatureUnit.Fahrenheit);

            control.MeasurementControl("measurementPressure").ValueAs<Measurement<PressureUnit>>()
                .Should().Be(29.95.As(PressureUnit.InchesOfMercury));
            control.MeasurementControl("measurementPressure").Should().HaveUnitSelected(PressureUnit.InchesOfMercury);

            control.TextBox("textBoxHumidity").Should().HaveText("78");
        }

        [Theory]
        [InlineData("0", Keys.Up, "1")]
        [InlineData("1", Keys.Up, "2")]
        [InlineData("1.5", Keys.Up, "2.5")]
        [InlineData("99.5", Keys.Up, "100")]
        [InlineData("100", Keys.Up, "100")]
        [InlineData("1", Keys.Down, "0")]
        [InlineData("0", Keys.Down, "0")]
        [InlineData("2.5", Keys.Down, "1.5")]
        [InlineData("0.5", Keys.Down, "0")]
        [InlineData("a", Keys.Up, "1")]
        [InlineData("a", Keys.Down, "0")]
        public void HumidityKeys(string org, Keys key, string res)
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AtmosphereControl>(5, 5, 100, 100);
            control.TextBox("textBoxHumidity").Text = org;
            var args = new KeyEventArgs(key);
            control.InvokeEventHandler("textBoxHumidity_KeyDown", args);
            control.TextBox("textBoxHumidity").Text.Should().Be(res);
        }

        [Fact]
        public void Set()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AtmosphereControl>(5, 5, 100, 100);
            var atmo = new Atmosphere(330.As(DistanceUnit.Foot), 31.05.As(PressureUnit.InchesOfMercury), 101.As(TemperatureUnit.Fahrenheit), 0.51);

            control.Atmosphere = atmo;

            control.MeasurementControl("measurementAltitude").ValueAs<Measurement<DistanceUnit>>()
                .Should().Be(330.As(DistanceUnit.Foot));
            control.MeasurementControl("measurementAltitude").Should().HaveUnitSelected(DistanceUnit.Foot);

            control.MeasurementControl("measurementTemperature").ValueAs<Measurement<TemperatureUnit>>()
                .Should().Be(101.As(TemperatureUnit.Fahrenheit));
            control.MeasurementControl("measurementTemperature").Should().HaveUnitSelected(TemperatureUnit.Fahrenheit);

            control.MeasurementControl("measurementPressure").ValueAs<Measurement<PressureUnit>>()
                .Should().Be(31.05.As(PressureUnit.InchesOfMercury));

            control.TextBox("textBoxHumidity").Should().HaveText("51");
        }

        [Fact]
        public void Get()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AtmosphereControl>(5, 5, 100, 100);

            control.MeasurementControl("measurementAltitude").Value = 330.As(DistanceUnit.Foot);
            control.MeasurementControl("measurementTemperature").Value = 101.As(TemperatureUnit.Fahrenheit);
            control.MeasurementControl("measurementPressure").Value = 31.05.As(PressureUnit.InchesOfMercury);
            control.TextBox("textBoxHumidity").Text = "51.5";

            var atmo = control.Atmosphere;

            atmo.Altitude.Should().Be(330.As(DistanceUnit.Foot));
            atmo.Temperature.Should().Be(101.As(TemperatureUnit.Fahrenheit));
            atmo.Pressure.Should().Be(31.05.As(PressureUnit.InchesOfMercury));
            atmo.Humidity.Should().Be(0.515);
        }
    }
}
