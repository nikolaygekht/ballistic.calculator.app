using BallisticCalculator;
using BallisticCalculator.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticCalculatorNet.InputPanels
{
    [BXmlElement("shot-data")]
    public class ShotData
    {
        [BXmlProperty(Name = "ammunition", ChildElement = true)]
        public AmmunitionLibraryEntry Ammunition { get; set; }

        [BXmlProperty(Name = "weapon", ChildElement = true)]
        public Rifle Weapon { get; set; }

        [BXmlProperty(Name = "atmosphere", ChildElement = true)]
        public Atmosphere Atmosphere { get; set; }

        [BXmlProperty(Name = "wind", Collection = true, Optional = true)]
        public WindCollection Wind { get; set; }

        [BXmlProperty(Name = "parameters", ChildElement = true)]
        public ShotParameters Parameters { get; set; }
    }
}
