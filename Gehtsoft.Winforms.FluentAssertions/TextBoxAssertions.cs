using System.Windows.Forms;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Gehtsoft.Winforms.FluentAssertions
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
    }
}
