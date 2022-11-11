using BallisticCalculator;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.InputPanels
{
    public class ChartController
    {
        private readonly MeasurementSystem mMeasurementSystem;
        private readonly AngularUnit mAngularUnits;
        private readonly TrajectoryChartMode mChartMode;
        private readonly TrajectoryPoint[] mTrajectory;

        public ChartController(MeasurementSystem measurementSystem, AngularUnit angularUnits,
                               TrajectoryChartMode chartMode, TrajectoryPoint[] trajectory)
        {
            mMeasurementSystem = measurementSystem;
            mAngularUnits = angularUnits;
            mChartMode = chartMode;
            mTrajectory = trajectory;
        }

        public string VelocityUnitsName => mMeasurementSystem == MeasurementSystem.Metric ? "m/s" : "fps";
        public string DistanceUnitsName => mMeasurementSystem == MeasurementSystem.Metric ? "m" : "yd";
        public string DropUnitsName => mMeasurementSystem == MeasurementSystem.Metric ? "cm" : "in";
        public string EnergyUnitsName => mMeasurementSystem == MeasurementSystem.Metric ? "J" : "ft-lb";
        public string AdjustmentUnitsName => mAngularUnits switch
        {
            AngularUnit.MOA => "MOA",
            AngularUnit.Mil => "Mil",
            AngularUnit.MRad => "MRad",
            AngularUnit.Thousand => "Ths",
            AngularUnit.CmPer100Meters => "cm/100m",
            AngularUnit.InchesPer100Yards => "in/100yd",
            _ => "Unknown",
        };

        public VelocityUnit VelocityUnits => mMeasurementSystem == MeasurementSystem.Metric ? VelocityUnit.MetersPerSecond : VelocityUnit.FeetPerSecond;
        public DistanceUnit DistanceUnits => mMeasurementSystem == MeasurementSystem.Metric ? DistanceUnit.Meter : DistanceUnit.Yard;
        public DistanceUnit DropUnits => mMeasurementSystem == MeasurementSystem.Metric ? DistanceUnit.Centimeter : DistanceUnit.Inch;
        public EnergyUnit EnergyUnits => mMeasurementSystem == MeasurementSystem.Metric ? EnergyUnit.Joule : EnergyUnit.FootPound;

        public string YAxisTitle => mChartMode switch
        {
            TrajectoryChartMode.Velocity => $"Velocity ({VelocityUnitsName})",
            TrajectoryChartMode.Mach => $"Mach",
            TrajectoryChartMode.Energy => $"Energy ({EnergyUnitsName})",
            TrajectoryChartMode.Drop => $"Drop ({DropUnitsName})",
            TrajectoryChartMode.DropAdjustment => $"Drop ({AdjustmentUnitsName})",
            TrajectoryChartMode.Windage => $"Windage ({DropUnitsName})",
            TrajectoryChartMode.WindageAdjustment => $"Windage ({AdjustmentUnitsName})",
            _ => "No data"
        };

        public string XAxisTitle => $"Range ({DistanceUnitsName})";

        public double[] GetXAxis()
        {
            var r = new double[mTrajectory.Length];
            for (int i = 0; i < mTrajectory.Length; i++)
                r[i] = mTrajectory[i].Distance.In(DistanceUnits);
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
                TrajectoryChartMode.Velocity => pt.Velocity.In(VelocityUnits),
                TrajectoryChartMode.Mach => pt.Mach,
                TrajectoryChartMode.Energy => pt.Energy.In(EnergyUnits),
                TrajectoryChartMode.Drop => pt.Drop.In(DropUnits),
                TrajectoryChartMode.DropAdjustment => pt.DropAdjustment.In(mAngularUnits),
                TrajectoryChartMode.Windage => pt.Windage.In(DropUnits),
                TrajectoryChartMode.WindageAdjustment => pt.WindageAdjustment.In(mAngularUnits),
                _ => 0
            };
        }
    }
}
