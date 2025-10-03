using BallisticCalculator;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.Types;

namespace BallisticCalculatorNet.InputPanels
{
    public interface IZeroAtmosphereControl
    {
        Atmosphere Atmosphere { get; set; }
        MeasurementSystem MeasurementSystem { get; set; }
    }
}
