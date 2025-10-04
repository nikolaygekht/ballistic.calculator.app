using BallisticCalculator;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.Types;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.InputPanels
{
    public class ChartController
    {
        private readonly AngularUnit mAngularUnits;
        private readonly TrajectoryChartMode mChartMode;
        private readonly DropBase mDropBase;
        private readonly TrajectoryPoint[] mTrajectory;
        private readonly MeasurementSystemController mMeasurementSystemController;

        public ChartController(MeasurementSystem measurementSystem, AngularUnit angularUnits,
                               TrajectoryChartMode chartMode, DropBase dropBase,
                               TrajectoryPoint[] trajectory)
        {
            mAngularUnits = angularUnits;
            mChartMode = chartMode;
            mTrajectory = trajectory;
            mDropBase = dropBase;
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
                r[i] = GetXAxisPoint(i);
            return r;
        }

        public double GetXAxisPoint(int index) => mTrajectory[index].Distance.In(mMeasurementSystemController.RangeUnit);

        public double[] GetYAxis()
        {
            var r = new double[mTrajectory.Length];
            for (int i = 0; i < mTrajectory.Length; i++)
                r[i] = GetYAXisPoint(i);
            return r;
        }

        public double GetYAXisPoint(int index)
        {
            var pt = mTrajectory[index];
            return mChartMode switch
            {
                TrajectoryChartMode.Velocity => pt.Velocity.In(mMeasurementSystemController.VelocityUnit),
                TrajectoryChartMode.Mach => pt.Mach,
                TrajectoryChartMode.Energy => pt.Energy.In(mMeasurementSystemController.EnergyUnit),
                TrajectoryChartMode.Drop => mDropBase == DropBase.SightLine ? pt.Drop.In(mMeasurementSystemController.AdjustmentUnit) : (pt.DropFlat).In(mMeasurementSystemController.AdjustmentUnit),
                TrajectoryChartMode.DropAdjustment => pt.DropAdjustment.In(mAngularUnits),
                TrajectoryChartMode.Windage => pt.Windage.In(mMeasurementSystemController.AdjustmentUnit),
                TrajectoryChartMode.WindageAdjustment => pt.WindageAdjustment.In(mAngularUnits),
                _ => 0
            };
        }
    }
}
