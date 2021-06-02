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
    public class TextBoxTest
    {
        [Fact]
        public void HaveNoText_Ok()
        {
            using var tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";
            tb.Text = "";

            ((Action)(() => tb.Should().HaveNoText())).Should().NotThrow();
        }

        [Fact]
        public void HaveNoText_Fail()
        {
            using var tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";
            tb.Text = "a";

            ((Action)(() => tb.Should().HaveNoText())).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveText_Ok()
        {
            using var tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";
            tb.Text = "a";

            ((Action)(() => tb.Should().HaveText("a"))).Should().NotThrow();
        }

        [Fact]
        public void HaveText_Fail()
        {
            using var tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";
            tb.Text = "b";

            ((Action)(() => tb.Should().HaveText("a"))).Should().Throw<XunitException>();
        }
    }
}
