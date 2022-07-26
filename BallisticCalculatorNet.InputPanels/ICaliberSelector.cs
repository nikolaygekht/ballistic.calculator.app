using System;
using System.Windows.Forms;
using BallisticCalculator.Data.Dictionary;

namespace BallisticCalculatorNet.InputPanels
{
    /// <summary>
    /// The interface to caliber selector
    /// </summary>
    public interface ICaliberSelector : IDisposable
    {
        public AmmunitionCaliber Caliber { get; set; }
        public bool Select(IWin32Window parent);
    }
}
