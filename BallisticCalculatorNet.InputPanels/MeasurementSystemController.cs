using BallisticCalculatorNet.Api;
using Gehtsoft.Measurements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BallisticCalculatorNet.Types;

namespace BallisticCalculatorNet.InputPanels
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "In future accuracy may become depeneded on parameters")]
    public class MeasurementSystemController
    {
        public MeasurementSystem MeasurementSystem { get; set; }
        public AngularUnit AngularUnit { get; set; }

        public MeasurementSystemController(MeasurementSystem measurementSystem)
        {
            MeasurementSystem = measurementSystem;
        }

        public static int RangeAccuracy => 0;
        public static int AdjustentAccuracy => 2;
        public static int VeloctyAccuracy => 0;
        public static int EnergyAccuracy => 0;
        public static int WeightAccuracy => 1;
        public static int MachAccuracy => 2;
        public static int AngularAccuracy => 2;
        public static int ClickAccuracy => 0;

        public static string RangeFormatString => $"N{RangeAccuracy}";
        public static string AdjustmentFormatString => $"N{AdjustentAccuracy}";
        public static string VelocityFormatString => $"N{VeloctyAccuracy}";
        public static string EnergyFormatString => $"N{EnergyAccuracy}";
        public static string WeightFormatString => $"N{WeightAccuracy}";
        public static string MachFormatString => $"N{MachAccuracy}";
        public static string AngularFormatString => $"N{AngularAccuracy}";
        public static string ClickFormatString => $"N{ClickAccuracy}";
        public static string TimeFormatString => "mm\\:ss\\.fff";

        public static string RangeFormatString1 => $"F{RangeAccuracy}";
        public static string AdjustmentFormatString1 => $"F{AdjustentAccuracy}";
        public static string VelocityFormatString1 => $"F{VeloctyAccuracy}";
        public static string EnergyFormatString1 => $"F{EnergyAccuracy}";
        public static string WeightFormatString1 => $"F{WeightAccuracy}";
        public static string ClickFormatString1 => $"F{ClickAccuracy}";
        public static string MachFormatString1 => $"F{MachAccuracy}";
        public static string AngularFormatString1 => $"F{AngularAccuracy}";


        public DistanceUnit RangeUnit => MeasurementSystem == MeasurementSystem.Metric ? DistanceUnit.Meter : DistanceUnit.Yard;
        public DistanceUnit AdjustmentUnit => MeasurementSystem == MeasurementSystem.Metric ? DistanceUnit.Centimeter : DistanceUnit.Inch;
        public VelocityUnit VelocityUnit => MeasurementSystem == MeasurementSystem.Metric ? VelocityUnit.MetersPerSecond : VelocityUnit.FeetPerSecond;
        public EnergyUnit EnergyUnit => MeasurementSystem == MeasurementSystem.Metric ? EnergyUnit.Joule : EnergyUnit.FootPound;
        public WeightUnit WeightUnit => MeasurementSystem == MeasurementSystem.Metric ? WeightUnit.Kilogram : WeightUnit.Pound;

        public string RangeUnitName => MeasurementSystem == MeasurementSystem.Metric ? "m" : "yd";
        public string AdjustmentUnitName => MeasurementSystem == MeasurementSystem.Metric ? "cm" : "in";
        public string VelocityUnitName => MeasurementSystem == MeasurementSystem.Metric ? "m/s" : "ft/s";
        public string EnergyUnitName => MeasurementSystem == MeasurementSystem.Metric ? "J" : "ft-lb";
        public string WeightUnitName => MeasurementSystem == MeasurementSystem.Metric ? "kg" : "lb";

        public string AngularUnitName => AngularUnit switch
        {
            AngularUnit.Radian => "rad",
            AngularUnit.Degree => "deg",
            AngularUnit.Gradian => "grad",
            AngularUnit.Turn => "turn",
            AngularUnit.MOA => "moa",
            AngularUnit.Mil => "mil",
            AngularUnit.Thousand => "th",
            AngularUnit.MRad => "mrad",
            AngularUnit.CmPer100Meters => "cm/100m",
            AngularUnit.InchesPer100Yards => "in/100yd",
            _ => "Unsupported"
        };
    }
}

