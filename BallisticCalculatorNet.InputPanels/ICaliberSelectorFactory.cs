namespace BallisticCalculatorNet.InputPanels
{
    /// <summary>
    /// The factory to create a caliber selector
    /// </summary>
    public interface ICaliberSelectorFactory
    {
        public ICaliberSelector Create();
    }
}
