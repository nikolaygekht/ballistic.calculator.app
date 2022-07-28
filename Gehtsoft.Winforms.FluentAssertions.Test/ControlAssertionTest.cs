using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;
using FluentAssertions;
using Xunit.Sdk;

namespace Gehtsoft.Winforms.FluentAssertions.Test
{
    public class ControlAssertionTest
    {
        [Fact]
        public void HaveControl_OK()
        {
            using var tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";

            ((Action)(() => tf.Should().HaveControl<TextBox>("testTextBox"))).Should().NotThrow();
        }

        [Fact]
        public void HaveControl_FailName()
        {
            using var tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";

            ((Action)(() => tf.Should().HaveControl<TextBox>("testTextBax"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveControl_FailType()
        {
            using var tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";

            ((Action)(() => tf.Should().HaveControl<ListBox>("testTextBox"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void ControlExtension_OK()
        {
            using var tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";

            tf.Control("testTextBox", typeof(TextBox)).Should().NotBeNull();
            tf.Control("testTextBox", typeof(TextBox)).Should().HaveType<TextBox>();

            tf.Control<TextBox>("testTextBox").Should().NotBeNull();
            tf.Control<TextBox>("testTextBox").Should().HaveType<TextBox>();
        }

        [Fact]
        public void ControlMatch_OK()
        {
            using var tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";

            tf.Should().HaveControl<TextBox>("testTextBox");

            ((Action)(() => tf.Control<TextBox>("testTextBox")
                .Should().MatchAs<TextBox>(tb => tb.Name == "testTextBox"))).Should().NotThrow();
        }

        [Fact]
        public void ControlMatch_FailNoControl()
        {
            using var tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";

            tf.Should().HaveControl<TextBox>("testTextBox");

            ((Action)(() => tf.Control<TextBox>("testTextBax")
                .Should().MatchAs<TextBox>(tb => tb.Name == "testTextBox"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void ControlMatch_FailPredicate()
        {
            using var tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";

            tf.Should().HaveControl<TextBox>("testTextBox");

            ((Action)(() => tf.Control<TextBox>("testTextBox")
                .Should().MatchAs<TextBox>(tb => tb.Name == "testTextBax"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void ControlExist_OK()
        {
            using var tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";

            ((Action)(() => tf.TextBox("testTextBox").Should().Exist())).Should().NotThrow();
        }

        [Fact]
        public void ControlExist_Fail()
        {
            using var tf = new TestForm();

            ((Action)(() => tf.TextBox("testTextBox").Should().Exist())).Should().Throw<XunitException>();
        }

        [Fact]
        public void ControlEnabled_OK()
        {
            using var tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";
            tb.Enabled = true;

            ((Action)(() => tf.TextBox("testTextBox").Should().BeEnabled())).Should().NotThrow();
        }

        [Fact]
        public void ControlEnabled_Fail()
        {
            using var tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";
            tb.Enabled = false;

            ((Action)(() => tf.TextBox("testTextBox").Should().BeEnabled())).Should().Throw<XunitException>();
        }

        [Fact]
        public void BeBefore_OK()
        {
            using var tf = new TestForm();
            var tb1 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb1.Name = "testTextBox1";
            var tb2 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb2.Name = "testTextBox2";
            var tb3 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb3.Name = "testTextBox3";

            ((Action)(() => tf.TextBox("testTextBox1").Should().BeBefore(tf.TextBox("testTextBox3")))).Should().NotThrow();
        }

        [Fact]
        public void BeBefore_Fail()
        {
            using var tf = new TestForm();
            var tb1 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb1.Name = "testTextBox1";
            var tb2 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb2.Name = "testTextBox2";
            var tb3 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb3.Name = "testTextBox3";

            ((Action)(() => tf.TextBox("testTextBox2").Should().BeBefore(tf.TextBox("testTextBox1")))).Should().Throw<XunitException>();
        }

        [Fact]
        public void BeImmediatelyBefore_OK()
        {
            using var tf = new TestForm();
            var tb1 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb1.Name = "testTextBox1";
            var tb2 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb2.Name = "testTextBox2";
            var tb3 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb3.Name = "testTextBox3";

            ((Action)(() => tf.TextBox("testTextBox1").Should().BeBefore(tf.TextBox("testTextBox2")))).Should().NotThrow();
        }

        [Fact]
        public void BeImmediatelyBefore_Fail ()
        {
            using var tf = new TestForm();
            var tb1 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb1.Name = "testTextBox1";
            var tb2 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb2.Name = "testTextBox2";
            var tb3 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb3.Name = "testTextBox3";

            ((Action)(() => tf.TextBox("testTextBox1").Should().BeImmediatelyBefore(tf.TextBox("testTextBox3")))).Should().Throw<XunitException>();
        }

        [Fact]
        public void BeAfter_OK()
        {
            using var tf = new TestForm();
            var tb1 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb1.Name = "testTextBox1";
            var tb2 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb2.Name = "testTextBox2";
            var tb3 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb3.Name = "testTextBox3";

            ((Action)(() => tf.TextBox("testTextBox3").Should().BeAfter(tf.TextBox("testTextBox1")))).Should().NotThrow();
        }

        [Fact]
        public void BeAfter_Fail()
        {
            using var tf = new TestForm();
            var tb1 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb1.Name = "testTextBox1";
            var tb2 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb2.Name = "testTextBox2";
            var tb3 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb3.Name = "testTextBox3";

            ((Action)(() => tf.TextBox("testTextBox1").Should().BeAfter(tf.TextBox("testTextBox3")))).Should().Throw<XunitException>();
        }

        [Fact]
        public void BeImmediatelyAfter_OK()
        {
            using var tf = new TestForm();
            var tb1 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb1.Name = "testTextBox1";
            var tb2 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb2.Name = "testTextBox2";
            var tb3 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb3.Name = "testTextBox3";

            ((Action)(() => tf.TextBox("testTextBox2").Should().BeAfter(tf.TextBox("testTextBox1")))).Should().NotThrow();
        }

        [Fact]
        public void BeImmediatelyAfter_Fail()
        {
            using var tf = new TestForm();
            var tb1 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb1.Name = "testTextBox1";
            var tb2 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb2.Name = "testTextBox2";
            var tb3 = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb3.Name = "testTextBox3";

            ((Action)(() => tf.TextBox("testTextBox3").Should().BeImmediatelyAfter(tf.TextBox("testTextBox1")))).Should().Throw<XunitException>();
        }

        [Fact]
        public void Controls()
        {
            using var tf = new TestForm();
            var tb1 = tf.AddControl<TextBox>(1, 1, 5, 5);
            var tb2 = tf.AddControl<TextBox>(1, 6, 5, 5);

            tf.Controls<TextBox>()
                .Should()
                .HaveCount(2)
                .And.Contain(tb1)
                .And.Contain(tb2);

            tf.Controls<ListBox>().Should().BeEmpty();
        }

    }
}
