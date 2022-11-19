using BallisticCalculator;
using BallisticCalculator.Serialization;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.InputPanels.DataList
{
    [BXmlElement("twist")]
    public class BarrelListItem : IDataListItem
    {
        [BXmlProperty("name", ChildElement = false)]
        public string Name { get; set; }

        [BXmlProperty("step", ChildElement = false)]
        public Measurement<DistanceUnit> Step { get; set; }

        [BXmlProperty("direction", ChildElement = false)]
        public TwistDirection TwistDirection { get; set; }
    }
}
