using System;
using System.Windows.Forms;
using BallisticCalculatorNet.MeasurementControl;
using FluentAssertions;
using FluentAssertions.Execution;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.UnitTest.Utils
{
    public class MeasurementControlAssertions : ControlAssertionsBase<MeasurementControl.MeasurementControl, MeasurementControlAssertions>
    {
        public MeasurementControlAssertions(MeasurementControl.MeasurementControl subject) : base(subject)
        {
        }

        public AndConstraint<MeasurementControlAssertions> HaveUnitType(MeasurementType type, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(control => control.MeasurementType == type)
                .FailWith("Expected {context:control} to have unit type {1}, but it has text '{0}'", Subject.MeasurementType, type);

            return new AndConstraint<MeasurementControlAssertions>(this);
        }

        public AndConstraint<MeasurementControlAssertions> HaveValue<T>(Measurement<T> value, string because = null, params object[] becauseParameters)
            where T : Enum
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(control => control.Value is Measurement<T> v && v == value)
                .FailWith("Expected {context:control} to have value '{1}', but it has value '{0}'", Subject.Value, value);

            return new AndConstraint<MeasurementControlAssertions>(this);
        }

        public AndConstraint<MeasurementControlAssertions> BeEmpty(string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(control => control.IsEmpty)
                .FailWith("Expected {context:control} to be empty, but it has value '{0}'", Subject.Value);

            return new AndConstraint<MeasurementControlAssertions>(this);
        }

        public AndConstraint<MeasurementControlAssertions> HaveExactValue<T>(Measurement<T> value, string because = null, params object[] becauseParameters)
           where T : Enum
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(control => control.Value is Measurement<T> v && v == value && v.Unit.Equals(value.Unit))
                .FailWith("Expected {context:control} to have exact value '{1}', but it has value '{0}'", Subject.Value, value);

            return new AndConstraint<MeasurementControlAssertions>(this);
        }

        public AndConstraint<MeasurementControlAssertions> HaveUnitSelected<T>(T value, string because = null, params object[] becauseParameters)
            where T : Enum
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(control => control.Unit.Equals(value))
                .FailWith("Expected {context:control} to have selected unit '{1}', but it has selected '{0}'", Subject.Unit, value);

            return new AndConstraint<MeasurementControlAssertions>(this);
        }
    }
}
