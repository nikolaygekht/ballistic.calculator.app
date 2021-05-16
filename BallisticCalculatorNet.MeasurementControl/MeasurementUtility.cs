using System;
using System.Collections.Generic;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.MeasurementControl
{
    public class MeasurementUtility
    {
        public sealed class Unit : IEquatable<Unit>
        {
            public string Name { get; }
            public object Value { get; }
            public Unit(string name, object value)
            {
                Name = name;
                Value = value;
            }

            public override string ToString()
            {
                return Name;
            }

            public bool Equals(Unit other)
            {
                return Name == other.Name && Value.Equals(other.Value);
            }
        }

        public Type MeasurementUnit { get; }
        public Type MeasurementType { get; }
        public IReadOnlyList<Unit> Units { get; }
        public Func<double, object, object> Activator { get; }
        public Func<object, double> ValueGetter { get; }
        public Func<object, object> UnitGetter { get; }
        public Func<object, string> TextGetter { get; }
        public Func<string, object> Parser { get; }

        public MeasurementUtility(Type unitType, Type type,
                                  IReadOnlyList<Unit> units,
                                  Func<double, object, object> activator,
                                  Func<object, double> valueGetter,
                                  Func<object, object> unitGetter,
                                  Func<object, string> textGetter,
                                  Func<string, object> parser)
        {
            MeasurementUnit = unitType;
            MeasurementType = type;
            Units = units;
            Activator = activator;
            ValueGetter = valueGetter;
            UnitGetter = unitGetter;
            TextGetter = textGetter;
            Parser = parser;
        }
    }
}
