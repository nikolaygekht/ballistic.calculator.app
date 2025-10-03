namespace BallisticCalculatorNet.Types
{
    /// <summary>
    /// The interface to a form that displays a chart
    /// </summary>
    public interface IChartDisplayForm
    {
        /// <summary>
        /// The data displayed on the chart
        /// </summary>
        TrajectoryChartMode ChartMode { get; set; }

        /// <summary>
        /// Force auto-zoom of Y axis to the visible data
        /// </summary>
        void UpdateYToVisibleArea();
    }
}
