using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using FluentAssertions;
using FluentAssertions.Execution;

namespace BallisticCalculatorNet.UnitTest.Utils
{
    public class ListBoxAssertions : ControlAssertionsBase<ListBox, ListBoxAssertions>
    {
        public ListBoxAssertions(ListBox subject) : base(subject)
        {
        }

        public AndConstraint<ListBoxAssertions> HaveNoItems(string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lb => lb.Items.Count == 0)
                .FailWith("Expected {context:control} to have no items, but it has '{0}'", Subject.Items.Count);

            return new AndConstraint<ListBoxAssertions>(this);
        }

        public AndConstraint<ListBoxAssertions> HaveItemsCount(int count, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lb => lb.Items.Count == count)
                .FailWith("Expected {context:control} to have {1} items, but it has {0}", Subject.Items.Count, count);

            return new AndConstraint<ListBoxAssertions>(this);
        }
        
        public AndConstraint<ListBoxAssertions> HaveItemMatching<T>(Expression<Func<T, bool>> predicate, string because = null, params object[] becauseParameters)
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

            return new AndConstraint<ListBoxAssertions>(this);
        }

        public AndConstraint<ListBoxAssertions> HaveNotItemsMatching<T>(Expression<Func<T, bool>> predicate, string because = null, params object[] becauseParameters)
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

            return new AndConstraint<ListBoxAssertions>(this);
        }

        public AndConstraint<ListBoxAssertions> HaveAllItemsMatching<T>(Expression<Func<T, bool>> predicate, string because = null, params object[] becauseParameters)
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

            return new AndConstraint<ListBoxAssertions>(this);
        }

        public AndConstraint<ListBoxAssertions> HaveIndexSelected(int index, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lb => lb.SelectedIndex == index)
                .FailWith("Expected {context:control} to have {1}st item selected, but it has {0}st", Subject.SelectedIndex, index);

            return new AndConstraint<ListBoxAssertions>(this);
        }

        public AndConstraint<ListBoxAssertions> SelectedObjectMatch<T>(Expression<Func<T, bool>> predicate, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lb => lb.SelectedItem is T t && predicate.Compile().Invoke(t))
                .FailWith("Expected {context:control} selected item to match {0} but it does not", predicate);

            return new AndConstraint<ListBoxAssertions>(this);
        }
    }

}
