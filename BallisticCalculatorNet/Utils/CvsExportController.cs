using BallisticCalculator;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.Types;
using BallisticCalculatorNet.InputPanels;
using Gehtsoft.Measurements;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticCalculatorNet.Utils
{
    public class CvsExportController
    {
        public TrajectoryPoint[] Trajectory { get; }
        public Sight Sight { get; }
        private readonly MeasurementSystemController mController;

        public CvsExportController(TrajectoryPoint[] trajectory, MeasurementSystem measurementSystem, Sight sight, AngularUnit angularUnits)
        {
            Trajectory = trajectory;
            Sight = sight;
            mController = new MeasurementSystemController(measurementSystem) { AngularUnit = angularUnits } ;
        }

        public IEnumerable<string> Prepare()
        {
            yield return Header();
            for (int i = 0; i < Trajectory.Length; i++)
                yield return Line(Trajectory[i]);
        }

        private string Header()
        {
            var sb = new StringBuilder();

            sb.Append($"Range ({mController.RangeUnitName}),")
              .Append($"Velocity ({mController.VelocityUnitName}),")
              .Append($"Mach,")
              .Append($"Path ({mController.AdjustmentUnitName}),")
              .Append($"Hold ({mController.AngularUnitName}),")
              .Append($"Clicks,")
              .Append($"Windage ({mController.AdjustmentUnitName}),")
              .Append($"Win. Adj. ({mController.AngularUnitName}),")
              .Append($"Clicks,")
              .Append($"Time,")
              .Append($"Energy ({mController.EnergyUnitName}),")
              .Append($"OGW ({mController.WeightUnitName})");

            return sb.ToString();
        }

        private string Line(TrajectoryPoint point)
        {
            var sb = new StringBuilder();
            var culture = CultureInfo.InvariantCulture;

            sb.Append(point.Distance.In(mController.RangeUnit).ToString(MeasurementSystemController.RangeFormatString1, culture))
              .Append(',')
              .Append(point.Velocity.In(mController.VelocityUnit).ToString(MeasurementSystemController.VelocityFormatString1, culture))
              .Append(',')
              .Append(point.Mach.ToString(MeasurementSystemController.MachFormatString, culture))
              .Append(',')
              .Append(point.Drop.In(mController.AdjustmentUnit).ToString(MeasurementSystemController.AdjustmentFormatString1, culture))
              .Append(',')
              .Append(point.DropAdjustment.In(mController.AngularUnit).ToString(MeasurementSystemController.AngularFormatString1, culture))
              .Append(',')
              .Append(GetClicks(point.Distance, point.DropAdjustment, Sight?.HorizontalClick, culture))
              .Append(',')
              .Append(point.Windage.In(mController.AdjustmentUnit).ToString(MeasurementSystemController.AdjustmentFormatString1, culture))
              .Append(',')
              .Append(point.WindageAdjustment.In(mController.AngularUnit).ToString(MeasurementSystemController.AngularFormatString1, culture))
              .Append(',')
              .Append(GetClicks(point.Distance, point.WindageAdjustment, Sight?.VerticalClick, culture))
              .Append(',')
              .Append(point.Time.ToString(MeasurementSystemController.TimeFormatString, culture))
              .Append(',')
              .Append(point.Energy.In(mController.EnergyUnit).ToString(MeasurementSystemController.EnergyFormatString1, culture))
              .Append(',')
              .Append(point.OptimalGameWeight.In(mController.WeightUnit).ToString(MeasurementSystemController.WeightFormatString1, culture));
            return sb.ToString();
        }

        private string GetClicks(Measurement<DistanceUnit> distance, Measurement<AngularUnit> windageAdjustment, Measurement<AngularUnit>? clickValue, CultureInfo culture)
        {
            if (distance.Value < 1 || clickValue == null)
                return "n/a";
            return ((int)Math.Round(windageAdjustment / clickValue.Value)).ToString(MeasurementSystemController.ClickFormatString1, culture);
        }
    }
}
