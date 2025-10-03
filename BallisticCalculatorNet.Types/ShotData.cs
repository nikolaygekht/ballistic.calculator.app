using BallisticCalculator;
using BallisticCalculator.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticCalculatorNet.Types
{
    /// <summary>
    /// The data to calculate a trajectory
    /// </summary>
    [BXmlElement("shot-data")]
    public class ShotData
    {
        /// <summary>
        /// Ammunition used
        /// </summary>
        [BXmlProperty(Name = "ammunition", ChildElement = true)]
        public AmmunitionLibraryEntry Ammunition { get; set; }

        /// <summary>
        /// Weapon used
        /// </summary>
        [BXmlProperty(Name = "weapon", ChildElement = true)]
        public Rifle Weapon { get; set; }

        /// <summary>
        /// Atmosphere at shot
        /// </summary>
        [BXmlProperty(Name = "atmosphere", ChildElement = true)]
        public Atmosphere Atmosphere { get; set; }

        /// <summary>
        /// Wind(s) at shot
        /// </summary>
        [BXmlProperty(Name = "wind", Collection = true, Optional = true)]
        public WindCollection Wind { get; set; }

        /// <summary>
        /// Shot parameters
        /// </summary>
        [BXmlProperty(Name = "parameters", ChildElement = true)]
        public ShotParameters Parameters { get; set; }
    }
}
