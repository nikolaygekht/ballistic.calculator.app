using System;
using System.Windows.Forms;
using Xunit;
using FluentAssertions;
using Xunit.Sdk;

namespace Gehtsoft.Winforms.FluentAssertions.Test
{
    public class ListViewTest
    {
        [Fact]
        public void FindControl()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            c.Name = "tc";

            tf.ListView("tc")
                .Should()
                .NotBeNull()
                .And
                .BeSameAs(c);
        }

        [Fact]
        public void HaveNoItems_OK()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            c.Name = "tc";

            ((Action)(() => c.Should().HaveNotItems())).Should().NotThrow();
        }

        [Fact]
        public void HaveNoItems_FAIL()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("");

            ((Action)(() => c.Should().HaveNotItems())).Should().Throw<XunitException>();
        }

        [Fact]
        public void BeInMode_OK()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            c.Name = "tc";
            c.View = View.LargeIcon;

            ((Action)(() => c.Should().BeInViewMode(View.LargeIcon))).Should().NotThrow();
        }

        [Fact]
        public void BeInMode_FAIL()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            c.Name = "tc";
            c.View = View.LargeIcon;

            ((Action)(() => c.Should().BeInViewMode(View.Details))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveNoSelection_OK()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("");

            ((Action)(() => c.Should().HaveNoSelection())).Should().NotThrow();
        }

        [Fact]
        public void HaveNoSelection_FAIL()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            c.Name = "tc";
            var item = c.Items.Add("");
            item.Selected = true;
            item.Focused = true;
            item.EnsureVisible();
            c.Select();

            ((Action)(() => c.Should().HaveNoSelection())).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveItemSelected_OK()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("");
            c.Items.Add("");
            var i = c.Items.Add("");
            c.Items.Add("");

            i.Selected = true;
            bool got_index = false;
            bool got_item = false;


            ((Action)(() => c.Should().HaveItemSelected((lv, index) =>
            {
                got_item = object.ReferenceEquals(lv, i);
                got_index = index == 2;
                return true;
            }))).Should().NotThrow();

            got_index.Should().BeTrue();
            got_item.Should().BeTrue();
        }

        [Fact]
        public void HaveItemSelected_FAIL_NothingSelected()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("");
            c.Items.Add("");
            var i = c.Items.Add("");
            c.Items.Add("");
            i.Selected = false;
            ((Action)(() => c.Should().HaveItemSelected((lv, index) => true))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveItemSelected_FAIL_Predicate()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("");
            c.Items.Add("");
            var i = c.Items.Add("");
            c.Items.Add("");
            i.Selected = true;

            ((Action)(() => c.Should().HaveItemSelected((lv, index) => false))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveItemInOrder_OK()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("a");
            c.Items.Add("b");
            c.Items.Add("c");
            c.Items.Add("d");

            ((Action)(() => c.Should().HaveItemsInOrder((lv0, lv1) => string.Compare(lv0.Text, lv1.Text) <= 0))).Should().NotThrow();
        }

        [Fact]
        public void HaveItemInOrder_Fail()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("d");
            c.Items.Add("c");
            c.Items.Add("b");
            c.Items.Add("a");

            ((Action)(() => c.Should().HaveItemsInOrder((lv0, lv1) => string.Compare(lv0.Text, lv1.Text) <= 0))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveItem_OK()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("a");
            c.Items.Add("b");
            c.Items.Add("c");
            c.Items.Add("d");

            ((Action)(() => c.Should().HaveItem((lv0) => lv0.Text == "b"))).Should().NotThrow();
        }

        [Fact]
        public void HaveItem_FAIL()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("a");
            c.Items.Add("b");
            c.Items.Add("c");
            c.Items.Add("d");

            ((Action)(() => c.Should().HaveItem((lv0) => lv0.Text == "x"))).Should().Throw<XunitException>();
        }
    }
}
