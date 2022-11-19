using BallisticCalculator.Serialization;
using Gehtsoft.Measurements;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BallisticCalculatorNet.InputPanels.DataList
{

    [BXmlElement("sight")]
    public class SightListItem : IDataListItem
    {
        [BXmlProperty("name", ChildElement = false)]
        public string Name { get; set; }

        [BXmlProperty("sight-height", ChildElement = false)]
        public Measurement<DistanceUnit> SightHeight { get; set; }

        [BXmlProperty("default-zero", ChildElement = false)]
        public Measurement<DistanceUnit> DefaultZero { get; set; }

        [BXmlProperty("horizontal-click", ChildElement = false, Optional = true)]
        public Measurement<AngularUnit>? HorizontalClick { get; set; }
        
        [BXmlProperty("vertical-click", ChildElement = false, Optional = true)]
        public Measurement<AngularUnit>? VerticalClick { get; set; }
    }
}
