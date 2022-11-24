using BallisticCalculator;
using BallisticCalculatorNet.Api;

namespace BallisticCalculatorNet.InputPanels
{
    public interface IZeroAtmosphereControl
    {
        Atmosphere Atmosphere { get; set; }
        MeasurementSystem MeasurementSystem { get; set; }
    }
}
