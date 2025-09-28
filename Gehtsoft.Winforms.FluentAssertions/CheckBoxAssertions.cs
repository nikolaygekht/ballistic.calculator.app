using System.Windows.Forms;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Gehtsoft.Winforms.FluentAssertions
{
    public class CheckBoxAssertions : ControlAssertionsBase<CheckBox, CheckBoxAssertions>
    {
        public CheckBoxAssertions(CheckBox subject, AssertionChain chain) : base(subject, chain)
        {
        }

        public AndConstraint<CheckBoxAssertions> Be(bool value, string because = null, params object[] becauseParameters) => value ? BeChecked(because, becauseParameters) : BeNotChecked(because, becauseParameters);

        public AndConstraint<CheckBoxAssertions> BeChecked(string because = null, params object[] becauseParameters)
        {
            mChain
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(cb => cb.Checked)
                .FailWith("Expected {context:control} to have be checked but it is not", Subject.Text);

            return new AndConstraint<CheckBoxAssertions>(this);
        }

        public AndConstraint<CheckBoxAssertions> BeNotChecked(string because = null, params object[] becauseParameters)
        {
            mChain
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(cb => !cb.Checked)
                .FailWith("Expected {context:control} to have be not checked but it is", Subject.Text);

            return new AndConstraint<CheckBoxAssertions>(this);
        }
    }
}
