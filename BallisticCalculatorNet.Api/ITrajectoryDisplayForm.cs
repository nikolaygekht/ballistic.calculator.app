using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.Api
{
    /// <summary>
    /// The form that displays a trajectory in any form
    /// </summary>
    public interface ITrajectoryDisplayForm
    {
        /// <summary>
        /// The measurement system chosen to display
        /// </summary>
        MeasurementSystem MeasurementSystem { get; set; }
        /// <summary>
        /// The angular units chosen to display
        /// </summary>
        AngularUnit AngularUnits { get; set; }     
    }
}
