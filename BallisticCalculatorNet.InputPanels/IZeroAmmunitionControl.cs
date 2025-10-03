using BallisticCalculator;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.Types;

namespace BallisticCalculatorNet.InputPanels
{
    public interface IZeroAmmunitionControl
    {
        Ammunition Ammunition { get; set; }
        MeasurementSystem MeasurementSystem { get; set; }
    }
}
