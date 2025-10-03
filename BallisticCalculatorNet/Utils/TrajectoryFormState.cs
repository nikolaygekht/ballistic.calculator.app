using BallisticCalculator.Serialization;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.Types;
using BallisticCalculatorNet.InputPanels;
using Gehtsoft.Measurements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticCalculatorNet.Utils
{
    [BXmlElement("trajectory")]
    public class TrajectoryFormState
    {
        [BXmlProperty(Name = "parameters", ChildElement = true)]
        public ShotData ShotData { get; set; }
        [BXmlProperty(Name = "measurement-system")]
        public MeasurementSystem MeasurementSystem { get; set; }
        [BXmlProperty(Name = "angular-units")]
        public AngularUnit AngularUnits { get; set; }
        [BXmlProperty(Name = "chart-mode", Optional = true)]
        public TrajectoryChartMode? ChartMode { get; set; }
    }
}
