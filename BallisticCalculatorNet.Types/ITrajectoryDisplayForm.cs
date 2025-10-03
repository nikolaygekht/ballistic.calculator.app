using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.Types
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

        /// <summary>
        /// The base value to display drop 
        /// </summary>
        DropBase DropBase { get; set; }
    }
}
