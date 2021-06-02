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
    public class ComboBoxTest
    {
        [Fact]
        public void HaveNoItems_OK()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";

            ((Action)(() => c.Should().HaveNoItems())).Should().NotThrow();
        }

        [Fact]
        public void HaveNoItems_Fail()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");

            ((Action)(() => c.Should().HaveNoItems())).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveItems_OK()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveItemsCount(2))).Should().NotThrow();
        }

        [Fact]
        public void HaveItems_Fail()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");
            c.Items.Add("Third Item");

            ((Action)(() => c.Should().HaveItemsCount(2))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveItem_OK()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveItemMatching<string>(s => s == "First Item"))).Should().NotThrow();
            ((Action)(() => c.Should().HaveItemMatching<string>(s => s == "Second Item"))).Should().NotThrow();
        }

        [Fact]
        public void HaveItem_Fail()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveItemMatching<string>(s => s == "Third Item"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveAllItems_OK()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveAllItemsMatching<string>(s => s.Contains("Item")))).Should().NotThrow();
        }

        [Fact]
        public void HaveAllItems_Fail()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveAllItemsMatching<string>(s => s.Contains("First")))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveNoItemsMatching_OK()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveNotItemsMatching<string>(s => s.Contains("Utem")))).Should().NotThrow();
        }

        [Fact]
        public void HaveNoItemsMatching_Fail()
        {
            using var tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveNotItemsMatching<string>(s => s.Contains("Item")))).Should().Throw<XunitException>();
        }
    }
}
