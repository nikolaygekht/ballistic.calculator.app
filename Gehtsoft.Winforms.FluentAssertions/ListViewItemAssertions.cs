using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace Gehtsoft.Winforms.FluentAssertions
{
    public class ListViewItemAssertions : ReferenceTypeAssertions<ListViewItem, ListViewItemAssertions>
    {
        public ListViewItemAssertions(ListViewItem subject) : base(subject)
        {
        }

        protected override string Identifier => "item";

        public AndConstraint<ListViewItemAssertions> HaveText(string text, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(control => Subject.Text == text)
                .FailWith("Expected {context:item} have name {0}", text);
            return new AndConstraint<ListViewItemAssertions>(this);
        }


        public AndConstraint<ListViewItemAssertions> HaveColumn(int index, string content, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(control => Subject.SubItems.Count > index)
                .FailWith("Expected {context:item} is expected to have at least {0} columns", index + 1)
                .Then
                .ForCondition(control => Subject.SubItems[index].Text == content)
                .FailWith("Expected {context:item} have content {0} in column {1}", content, index);
            return new AndConstraint<ListViewItemAssertions>(this);
        }

        public AndConstraint<ListViewItemAssertions> HaveTag<T>(Expression<Func<T, bool>> predicate, string because = null, params object[] becauseParameters)
            where T : class
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(control => Subject.Tag is T && predicate.Compile().Invoke(Subject.Tag as T))
                .FailWith("Expected {context:item} have non-null tag matching predicate {0}", predicate);
            return new AndConstraint<ListViewItemAssertions>(this);
        }
    }
}
