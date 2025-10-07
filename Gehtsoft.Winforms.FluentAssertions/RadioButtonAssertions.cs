using System.Windows.Forms;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Gehtsoft.Winforms.FluentAssertions
{
    public class RadioButtonAssertions : ControlAssertionsBase<RadioButton, RadioButtonAssertions>
    {
        public RadioButtonAssertions(RadioButton subject) : base(subject)
        {
        }

        public AndConstraint<RadioButtonAssertions> Be(bool value, string because = null, params object[] becauseParameters) => value ? BeChecked(because, becauseParameters) : BeNotChecked(because, becauseParameters);

        public AndConstraint<RadioButtonAssertions> BeChecked(string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(cb => cb.Checked)
                .FailWith("Expected {context:control} to have be checked but it is not", Subject.Text);

            return new AndConstraint<RadioButtonAssertions>(this);
        }

        public AndConstraint<RadioButtonAssertions> BeNotChecked(string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(cb => !cb.Checked)
                .FailWith("Expected {context:control} to have be not checked but it is", Subject.Text);

            return new AndConstraint<RadioButtonAssertions>(this);
        }
    }
}
