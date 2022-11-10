using BallisticCalculator;
using Gehtsoft.Measurements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet.InputPanels
{
    public partial class AtmosphereControl : UserControl
    {
        public AtmosphereControl()
        {
            InitializeComponent();
        }

        private MeasurementSystem mMeasurementSystem = MeasurementSystem.Metric;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasurementSystem MeasurementSystem
        {
            get => mMeasurementSystem;
            set
            {
                mMeasurementSystem = value;
                UpdateSystem();
            }
        }

        private void UpdateSystem()
        {
            if (mMeasurementSystem == MeasurementSystem.Metric)
            {
                measurementAltitude.ChangeUnit(DistanceUnit.Meter, 0);
                measurementPressure.ChangeUnit(PressureUnit.MillimetersOfMercury, 1);
                measurementTemperature.ChangeUnit(TemperatureUnit.Celsius, 1);
            } 
            else if (mMeasurementSystem == MeasurementSystem.Imperial)
            {
                measurementAltitude.ChangeUnit(DistanceUnit.Foot, 0);
                measurementPressure.ChangeUnit(PressureUnit.InchesOfMercury, 2);
                measurementTemperature.ChangeUnit(TemperatureUnit.Fahrenheit, 1);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Atmosphere Atmosphere
        {
            get
            {
                var altitude = measurementAltitude.ValueAs<Measurement<DistanceUnit>>();
                var temperature = measurementTemperature.ValueAs< Measurement<TemperatureUnit>>();
                var pressure = measurementPressure.ValueAs<Measurement<PressureUnit>>();
                if (!double.TryParse(textBoxHumidity.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out double humidty))
                    humidty = 0;
                humidty /= 100;
                return new Atmosphere(altitude, pressure, temperature, humidty);
            }
            set
            {
                if (value == null)
                    SetDefaultAtmosphere();
                else
                {
                    measurementAltitude.Value = value.Altitude;
                    measurementPressure.Value = value.Pressure;
                    measurementTemperature.Value = value.Temperature;
                    textBoxHumidity.Text = (value.Humidity * 100).ToString(CultureInfo.CurrentCulture);
                }
            }
        }

        private void SetDefaultAtmosphere()
        {
            var atmosphere = new Atmosphere();
            if (mMeasurementSystem == MeasurementSystem.Metric)
                atmosphere = new Atmosphere(0.As(DistanceUnit.Meter), 760.As(PressureUnit.MillimetersOfMercury), 15.As(TemperatureUnit.Celsius), 0.78);
            else if (mMeasurementSystem == MeasurementSystem.Imperial)
                atmosphere = new Atmosphere(0.As(DistanceUnit.Foot), 29.95.As(PressureUnit.InchesOfMercury), 59.As(TemperatureUnit.Fahrenheit), 0.78);
            Atmosphere = atmosphere;
        }

        private void buttonReset_Click(object sender, EventArgs e) => SetDefaultAtmosphere();

        private void textBoxHumidity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && e.Modifiers == Keys.None)
            {
                if (!double.TryParse(textBoxHumidity.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out var humidty))
                    humidty = 0;
                humidty += 1;
                if (humidty > 100)
                    humidty = 100;
                textBoxHumidity.Text = humidty.ToString(CultureInfo.CurrentCulture);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down && e.Modifiers == Keys.None)
            {
                if (!double.TryParse(textBoxHumidity.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out var humidty))
                    humidty = 0;
                humidty -= 1;
                if (humidty < 0)
                    humidty = 0;
                textBoxHumidity.Text = humidty.ToString(CultureInfo.CurrentCulture);
                e.Handled = true;
            }
        }
    }
}
