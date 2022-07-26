namespace BallisticCalculatorNet.InputPanels
{
    internal class CaliberSelectorFactory : ICaliberSelectorFactory
    {
        public ICaliberSelector Create() => new CaliberSelectorForm();
    }
}


