using BallisticCalculator.Serialization;

namespace BallisticCalculatorNet.InputPanels.DataList
{
    [BXmlElement("dictionary")]
    public class DataItemDictionary
    {
        [BXmlProperty("sights", Collection = true, Optional = true)]
        public DataListCollection<SightListItem> Sights { get; } = new DataListCollection<SightListItem>();
        [BXmlProperty("barrels", Collection = true, Optional = true)]
        public DataListCollection<BarrelListItem> Barrels { get; } = new DataListCollection<BarrelListItem>();
    }
}
