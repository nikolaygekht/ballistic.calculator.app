using BallisticCalculator;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.InputPanels
{
    public class ChartController
    {
        private readonly AngularUnit mAngularUnits;
        private readonly TrajectoryChartMode mChartMode;
        private readonly TrajectoryPoint[] mTrajectory;
        private readonly MeasurementSystemController mMeasurementSystemController;

        public ChartController(MeasurementSystem measurementSystem, AngularUnit angularUnits,
                               TrajectoryChartMode chartMode, TrajectoryPoint[] trajectory)
        {
            mAngularUnits = angularUnits;
            mChartMode = chartMode;
            mTrajectory = trajectory;
            mMeasurementSystemController = new MeasurementSystemController(measurementSystem) { AngularUnit = angularUnits };
        }

        public string YAxisTitle => mChartMode switch
        {
            TrajectoryChartMode.Velocity => $"Velocity ({mMeasurementSystemController.VelocityUnitName})",
            TrajectoryChartMode.Mach => $"Mach",
            TrajectoryChartMode.Energy => $"Energy ({mMeasurementSystemController.EnergyUnitName})",
            TrajectoryChartMode.Drop => $"Drop ({mMeasurementSystemController.AdjustmentUnitName})",
            TrajectoryChartMode.DropAdjustment => $"Drop ({mMeasurementSystemController.AngularUnitName})",
            TrajectoryChartMode.Windage => $"Windage ({mMeasurementSystemController.AdjustmentUnitName})",
            TrajectoryChartMode.WindageAdjustment => $"Windage ({mMeasurementSystemController.AngularUnitName})",
            _ => "No data"
        };

        public string XAxisTitle => $"Range ({mMeasurementSystemController.RangeUnitName})";

        public double[] GetXAxis()
        {
            var r = new double[mTrajectory.Length];
            for (int i = 0; i < mTrajectory.Length; i++)
                r[i] = mTrajectory[i].Distance.In(mMeasurementSystemController.RangeUnit);
            return r;
        }

        public double[] GetYAxis()
        {
            var r = new double[mTrajectory.Length];
            for (int i = 0; i < mTrajectory.Length; i++)
                r[i] = GetYAXisPoint(i);
            return r;
        }

        private double GetYAXisPoint(int index)
        {
            var pt = mTrajectory[index];
            return mChartMode switch
            {
                TrajectoryChartMode.Velocity => pt.Velocity.In(mMeasurementSystemController.VelocityUnit),
                TrajectoryChartMode.Mach => pt.Mach,
                TrajectoryChartMode.Energy => pt.Energy.In(mMeasurementSystemController.EnergyUnit),
                TrajectoryChartMode.Drop => pt.Drop.In(mMeasurementSystemController.AdjustmentUnit),
                TrajectoryChartMode.DropAdjustment => pt.DropAdjustment.In(mAngularUnits),
                TrajectoryChartMode.Windage => pt.Windage.In(mMeasurementSystemController.AdjustmentUnit),
                TrajectoryChartMode.WindageAdjustment => pt.WindageAdjustment.In(mAngularUnits),
                _ => 0
            };
        }
    }
}
