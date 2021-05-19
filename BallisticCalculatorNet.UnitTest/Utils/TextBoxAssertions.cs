using System.Windows.Forms;
using FluentAssertions;
using FluentAssertions.Execution;

namespace BallisticCalculatorNet.UnitTest.Utils
{
    public class TextBoxAssertions : ControlAssertionsBase<TextBox, TextBoxAssertions>
    {
        public TextBoxAssertions(TextBox subject) : base(subject)
        {
        }

        public AndConstraint<TextBoxAssertions> HaveNoText(string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject.Text)
                .ForCondition(text => string.IsNullOrEmpty(text))
                .FailWith("Expected {context:control} to have not text, but it has text '{0}'", Subject.Text);

            return new AndConstraint<TextBoxAssertions>(this);
        }

        public AndConstraint<TextBoxAssertions> HaveText(string text, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject.Text)
                .ForCondition(t => t == text)
                .FailWith("Expected {context:control} to have text '{1}', but it has text '{0}'", Subject.Text, text);

            return new AndConstraint<TextBoxAssertions>(this);
        }
    }
}
