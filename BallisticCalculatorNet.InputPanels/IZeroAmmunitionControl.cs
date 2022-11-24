using BallisticCalculator;
using BallisticCalculatorNet.Api;

namespace BallisticCalculatorNet.InputPanels
{
    public interface IZeroAmmunitionControl
    {
        Ammunition Ammunition { get; set; }
        MeasurementSystem MeasurementSystem { get; set; }
    }
}
