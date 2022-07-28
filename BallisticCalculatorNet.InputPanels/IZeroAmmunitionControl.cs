using BallisticCalculator;

namespace BallisticCalculatorNet.InputPanels
{
    public interface IZeroAmmunitionControl
    {
        Ammunition Ammunition { get; set; }
        MeasurementSystem MeasurementSystem { get; set; }
    }
}
