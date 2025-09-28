using System;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Xml.Linq;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Gehtsoft.Winforms.FluentAssertions
{
    public class ListViewAssertions : ControlAssertionsBase<ListView, ListViewAssertions>
    {
        public ListViewAssertions(ListView subject, AssertionChain chain) : base(subject, chain)
        {
        }

        public AndConstraint<ListViewAssertions> HaveNotItems(string because = null, params object[] becauseParameters)
        {
            mChain
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lv => lv.Items.Count == 0)
                .FailWith("Expected {context:control} be empty");

            return new AndConstraint<ListViewAssertions>(this);
        }

        public AndConstraint<ListViewAssertions> HaveItems(string because = null, params object[] becauseParameters)
        {
            mChain
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lv => lv.Items.Count != 0)
                .FailWith("Expected {context:control} be not empty");

            return new AndConstraint<ListViewAssertions>(this);
        }

        public AndConstraint<ListViewAssertions> HaveItem(Func<ListViewItem, bool> predicate, string because = null, params object[] becauseParameters)
        {
            mChain
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lv =>
                {
                    for (int i = 0; i < lv.Items.Count; i++)
                        if (predicate(lv.Items[i]))
                            return true;
                    return false;
                })
                .FailWith("Expected {context:control} have the item matching predicate but it does not");
            return new AndConstraint<ListViewAssertions>(this);
        }

        public AndConstraint<ListViewAssertions> BeInViewMode(View viewMode, string because = null, params object[] becauseParameters)
        {
            mChain
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lv => lv.View == viewMode)
                .FailWith("Expected {context:control} be in view mode {0}", viewMode);

            return new AndConstraint<ListViewAssertions>(this);
        }

        public AndConstraint<ListViewAssertions> HaveNoSelection(string because = null, params object[] becauseParameters)
        {
            mChain
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lv =>
                {
                    for (int i = 0; i < lv.Items.Count; i++)
                        if (lv.Items[i].Selected)
                            return false;
                    return true;
                })
                .FailWith("Expected {context:control} to have no selection");

            return new AndConstraint<ListViewAssertions>(this);
        }

        public AndConstraint<ListViewAssertions> HaveItemSelected(Func<ListViewItem, int, bool> predicate, string because = null, params object[] becauseParameters)
        {
            mChain
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lv =>
                {
                    for (int i = 0; i < lv.Items.Count; i++)
                        if (lv.Items[i].Selected && predicate(lv.Items[i], i))
                            return true;
                    return false;
                })
                .FailWith("Expected {context:control} to have a selection matching predicate");
            return new AndConstraint<ListViewAssertions>(this);
        }

        public AndConstraint<ListViewAssertions> HaveItemsInOrder(Func<ListViewItem, ListViewItem, bool> predicate, string because = null, params object[] becauseParameters)
        {
            mChain
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(lv =>
                {
                    for (int i = 1; i < lv.Items.Count; i++)
                    {
                        if (!predicate(lv.Items[i - 1], lv.Items[i]))
                            return false;
                    }
                    return true;
                })
                .FailWith("Expected {context:control} to have item in the order matching the predicate");
            return new AndConstraint<ListViewAssertions>(this);
        }
    }
}
