using BallisticCalculator;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.Types;
using BallisticCalculatorNet.InputPanels;
using BallisticCalculatorNet.Utils;
using Gehtsoft.Measurements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet
{
    public partial class ShotParametersForm : Form
    {
        public ShotParametersForm()
        {
            InitializeComponent();
        }

        public ShotParametersForm(MeasurementSystem measurementSystem) : this(measurementSystem, GetDefaultParameters(measurementSystem))
        {
            
        }

        public ShotParametersForm(MeasurementSystem measurementSystem, ShotData shotParameters) : this()
        {
            MeasurementSystem = measurementSystem;
            ShotParameters = shotParameters;
        }

        public MeasurementSystem MeasurementSystem
        {
            get => shotDataControl.MeasurementSystem;
            set => shotDataControl.MeasurementSystem = value;
        }

        public ShotData ShotParameters
        {
            get => shotDataControl.ShotData;
            set => shotDataControl.ShotData = value;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            var shotData = ShotParameters;
            var validator = new ShotParametersValidator();
            if (!validator.Validate(shotData))
            {
                var sb = new StringBuilder();
                foreach (var error in validator.Errors)
                    sb.AppendLine(error);

                MessageBox.Show(this, sb.ToString(), "Shot cannot be calculated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }

        private static ShotData GetDefaultParameters(MeasurementSystem measurementSystem)
        {
            var metric = measurementSystem == MeasurementSystem.Metric;
            var distanceUnit =  metric ? DistanceUnit.Meter : DistanceUnit.Yard;
            var distanceUnit1 = metric ? DistanceUnit.Meter : DistanceUnit.Foot;
            var dimensionUnit = metric ? DistanceUnit.Millimeter : DistanceUnit.Inch;
            var pressureUnit = metric ? PressureUnit.MillimetersOfMercury : PressureUnit.InchesOfMercury;
            var temperatureUnit = metric ? TemperatureUnit.Celsius : TemperatureUnit.Fahrenheit;
            var atmosphere = new Atmosphere();

            return new ShotData()
            {
                Atmosphere = new Atmosphere(
                    0.As(distanceUnit1),
                    atmosphere.Pressure.To(pressureUnit),
                    atmosphere.Temperature.To(temperatureUnit),
                    atmosphere.Humidity),
                Weapon = new Rifle()
                {
                    Sight = new Sight()
                    {
                        SightHeight = new Measurement<DistanceUnit>(metric ? 50 : 1.5, dimensionUnit),
                    },
                    Zero = new ZeroingParameters()
                    {
                        Distance = new Measurement<DistanceUnit>(100, distanceUnit),
                    }
                },
                Parameters = new ShotParameters()
                {
                    MaximumDistance = new Measurement<DistanceUnit>(1000, distanceUnit),
                    Step = new Measurement<DistanceUnit>(100, distanceUnit),
                }
            };
        }
    }
}
