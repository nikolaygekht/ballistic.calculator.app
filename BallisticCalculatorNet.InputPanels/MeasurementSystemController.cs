using Gehtsoft.Measurements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int RangeAccuracy => 0;
        public int AdjustentAccuracy => 2;
        public int VeloctyAccuracy => 0;
        public int EnergyAccuracy => 0;
        public int WeightAccuracy => 1;
        public int MachAccuracy => 2;
        public int AngularAccuracy => 2;
        public int ClickAccuracy => 0;

        public string RangeFormatString => $"N{RangeAccuracy}";
        public string AdjustmentFormatString => $"N{AdjustentAccuracy}";
        public string VelocityFormatString => $"N{VeloctyAccuracy}";
        public string EnergyFormatString => $"N{EnergyAccuracy}";
        public string WeightFormatString => $"N{WeightAccuracy}";
        public string MachFormatString => $"N{MachAccuracy}";
        public string AngularFormatString => $"N{AngularAccuracy}";
        public string ClickFormatString => $"N{ClickAccuracy}";
        public string TimeFormatString => "mm\\:ss\\.fff";

        public string RangeFormatString1 => $"F{RangeAccuracy}";
        public string AdjustmentFormatString1 => $"F{AdjustentAccuracy}";
        public string VelocityFormatString1 => $"F{VeloctyAccuracy}";
        public string EnergyFormatString1 => $"F{EnergyAccuracy}";
        public string WeightFormatString1 => $"F{WeightAccuracy}";
        public string MachFormatString1 => $"F{MachAccuracy}";
        public string AngularFormatString1 => $"F{AngularAccuracy}";
        public string ClickFormatString1 => $"F{ClickAccuracy}";


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

