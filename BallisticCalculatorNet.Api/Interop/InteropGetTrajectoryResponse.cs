using BallisticCalculator;
using BallisticCalculatorNet.Types;
using BallisticCalculator.Serialization;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.Api.Interop
{
    [BXmlElement("trajectory-response")]
    public class InteropGetTrajectoryResponse
    {
        [BXmlProperty(Name = "shot-data", ChildElement = true)]
        public ShotData ShotData { get; set; }
        [BXmlProperty(Name = "trajectory", Collection = true)]
        public TrajectoryPoint[] Trajectory { get; set; }
        [BXmlProperty(Name = "measurement-system", ChildElement = false)]
        public MeasurementSystem MeasurementSystem { get; set; }
        [BXmlProperty(Name = "angular-units", ChildElement = false)]
        public AngularUnit  AngularUnits { get; set; }
    }
}
