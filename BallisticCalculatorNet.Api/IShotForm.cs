using BallisticCalculator;

namespace BallisticCalculatorNet.Api
{
    /// <summary>
    /// The interface to a form that consists of a shot
    /// </summary>
    public interface IShotForm : ITrajectoryDisplayForm
    {
        /// <summary>
        /// The shot parameters
        /// </summary>
        ShotData ShotData { get; set; }
        
        /// <summary>
        /// The calculated trajectory
        /// </summary>
        TrajectoryPoint[] Trajectory { get; }
    }
}
