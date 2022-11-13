using BallisticCalculatorNet.InputPanels;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet
{
    public interface ITrajectoryDisplayForm
    {
        MeasurementSystem MeasurementSystem { get; set; }
        AngularUnit AngularUnits { get; set; }       
    }
}
