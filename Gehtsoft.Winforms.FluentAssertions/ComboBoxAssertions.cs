using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Gehtsoft.Winforms.FluentAssertions
{
    public class ComboBoxAssertions : ControlAssertionsBase<ComboBox, ComboBoxAssertions>
    {
        public ComboBoxAssertions(ComboBox subject) : base(subject)
        {
        }

        public AndConstraint<ComboBoxAssertions> HaveNoItems(string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lb => lb.Items.Count == 0)
                .FailWith("Expected {context:control} to have no items, but it has '{0}'", Subject.Items.Count);

            return new AndConstraint<ComboBoxAssertions>(this);
        }

        public AndConstraint<ComboBoxAssertions> HaveItemsCount(int count, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lb => lb.Items.Count == count)
                .FailWith("Expected {context:control} to have {1} items, but it has {0}", Subject.Items.Count, count);

            return new AndConstraint<ComboBoxAssertions>(this);
        }

        public AndConstraint<ComboBoxAssertions> HaveItemMatching<T>(Expression<Func<T, bool>> predicate, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lb =>
                {
                    var f = predicate.Compile();
                    foreach (object o in lb.Items)
                        if (o is T t && f(t))
                            return true;
                    return false;
                })
                .FailWith("Expected {context:control} to have item matching {0}, but it has no such items", predicate);

            return new AndConstraint<ComboBoxAssertions>(this);
        }

        public AndConstraint<ComboBoxAssertions> HaveNotItemsMatching<T>(Expression<Func<T, bool>> predicate, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lb =>
                {
                    var f = predicate.Compile();
                    foreach (object o in lb.Items)
                        if (o is T t && f(t))
                            return false;
                    return true;
                })
                .FailWith("Expected {context:control} to have no items matching {0}, but it has", predicate);

            return new AndConstraint<ComboBoxAssertions>(this);
        }

        public AndConstraint<ComboBoxAssertions> HaveAllItemsMatching<T>(Expression<Func<T, bool>> predicate, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lb =>
                {
                    var f = predicate.Compile();
                    foreach (object o in lb.Items)
                        if (o is T t && !f(t))
                            return false;
                    return true;
                })
                .FailWith("Expected {context:control} to have all items matching {0}, but it doesn't", predicate);

            return new AndConstraint<ComboBoxAssertions>(this);
        }

        public AndConstraint<ComboBoxAssertions> HaveIndexSelected(int index, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lb => lb.SelectedIndex == index)
                .FailWith("Expected {context:control} to have {1}st item selected, but it has {0}st", Subject.SelectedIndex, index);

            return new AndConstraint<ComboBoxAssertions>(this);
        }

        public AndConstraint<ComboBoxAssertions> SelectedObjectMatch<T>(Expression<Func<T, bool>> predicate, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lb => lb.SelectedItem is T t && predicate.Compile().Invoke(t))
                .FailWith("Expected {context:control} selected item to match {0} but it does not", predicate);

            return new AndConstraint<ComboBoxAssertions>(this);
        }

        public AndConstraint<ComboBoxAssertions> HaveText(string text, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject.Text)
                .ForCondition(t => t == text)
                .FailWith("Expected {context:control} to have text '{1}', but it has text '{0}'", Subject.Text, text);

            return new AndConstraint<ComboBoxAssertions>(this);
        }
    }
}
