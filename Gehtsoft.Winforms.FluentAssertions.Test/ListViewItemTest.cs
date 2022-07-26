using System;
using System.Windows.Forms;
using Xunit;
using FluentAssertions;
using Xunit.Sdk;

namespace Gehtsoft.Winforms.FluentAssertions.Test
{
    public class ListViewItemTest
    {
        [Fact]
        public void HaveText_OK()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            var i = c.Items.Add("a");

            ((Action)(() => i.Should().HaveText("a"))).Should().NotThrow();
        }

        [Fact]
        public void HaveText_Fail()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            var i = c.Items.Add("a");

            ((Action)(() => i.Should().HaveText("b"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveColumn_OK()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            var i = c.Items.Add("a");
            i.SubItems.Add("b");
            ((Action)(() => i.Should().HaveColumn(1, "b"))).Should().NotThrow();
        }

        [Fact]
        public void HaveColumn_Fail_Content()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            var i = c.Items.Add("a");
            i.SubItems.Add("b");
            ((Action)(() => i.Should().HaveColumn(1, "c"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveColumn_Fail_Index()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            var i = c.Items.Add("a");
            i.SubItems.Add("b");
            ((Action)(() => i.Should().HaveColumn(2, "b"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveTag_OK()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            var i = c.Items.Add("a");
            i.Tag = "t";
            ((Action)(() => i.Should().HaveTag<string>(t => t == "t"))).Should().NotThrow();
        }

        [Fact]
        public void HaveTag_FAIL_NoTag()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            var i = c.Items.Add("a");
            ((Action)(() => i.Should().HaveTag<string>(t => t == "t"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveTag_FAIL_WrongType()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            var i = c.Items.Add("a");
            i.Tag = 32;
            ((Action)(() => i.Should().HaveTag<string>(t => t == "t"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveTag_FAIL_Predicate()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ListView>(1, 1, 5, 5);
            var i = c.Items.Add("a");
            i.Tag = "x";
            ((Action)(() => i.Should().HaveTag<string>(t => t == "t"))).Should().Throw<XunitException>();
        }
    }
}
