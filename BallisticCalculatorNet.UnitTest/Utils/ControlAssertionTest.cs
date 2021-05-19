using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;
using FluentAssertions;
using Xunit.Sdk;
using BallisticCalculatorNet.MeasurementControl;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.UnitTest.Utils
{
    public class ControlAssertionTest
    {
        [Fact]
        public void HaveControl_OK()
        {
            using TestForm tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";

            ((Action)(() => tf.Should().HaveControl<TextBox>("testTextBox"))).Should().NotThrow();
        }

        [Fact]
        public void HaveControl_FailName()
        {
            using TestForm tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";

            ((Action)(() => tf.Should().HaveControl<TextBox>("testTextBax"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveControl_FailType()
        {
            using TestForm tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";

            ((Action)(() => tf.Should().HaveControl<ListBox>("testTextBox"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void ControlExtension_OK()
        {
            using TestForm tf = new TestForm();
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
            using TestForm tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";

            tf.Should().HaveControl<TextBox>("testTextBox");

            ((Action)(() => tf.Control<TextBox>("testTextBox")
                .Should().MatchAs<TextBox>(tb => tb.Name == "testTextBox"))).Should().NotThrow();
        }

        [Fact]
        public void ControlMatch_FailNoControl()
        {
            using TestForm tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";

            tf.Should().HaveControl<TextBox>("testTextBox");

            ((Action)(() => tf.Control<TextBox>("testTextBax")
                .Should().MatchAs<TextBox>(tb => tb.Name == "testTextBox"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void ControlMatch_FailPredicate()
        {
            using TestForm tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";

            tf.Should().HaveControl<TextBox>("testTextBox");

            ((Action)(() => tf.Control<TextBox>("testTextBox")
                .Should().MatchAs<TextBox>(tb => tb.Name == "testTextBax"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void ControlExist_OK()
        {
            using TestForm tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";

            ((Action)(() => tf.TextBox("testTextBox").Should().Exist())).Should().NotThrow();
        }
        [Fact]
        public void ControlExist_Fail()
        {
            using TestForm tf = new TestForm();

            ((Action)(() => tf.TextBox("testTextBox").Should().Exist())).Should().Throw<XunitException>();
        }

        [Fact]
        public void TextBox_HaveNoText_Ok()
        {
            using TestForm tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";
            tb.Text = "";

            ((Action)(() => tb.Should().HaveNoText())).Should().NotThrow();
        }

        [Fact]
        public void TextBox_HaveNoText_Fail()
        {
            using TestForm tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";
            tb.Text = "a";

            ((Action)(() => tb.Should().HaveNoText())).Should().Throw<XunitException>();
        }

        [Fact]
        public void TextBox_HaveText_Ok()
        {
            using TestForm tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";
            tb.Text = "a";

            ((Action)(() => tb.Should().HaveText("a"))).Should().NotThrow();
        }

        [Fact]
        public void TextBox_HaveText_Fail()
        {
            using TestForm tf = new TestForm();
            var tb = tf.AddControl<TextBox>(1, 1, 5, 5);
            tb.Name = "testTextBox";
            tb.Text = "b";

            ((Action)(() => tb.Should().HaveText("a"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void ListBox_HaveNoItems_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ListBox>(1, 1, 5, 5);
            c.Name = "tc";

            ((Action)(() => c.Should().HaveNoItems())).Should().NotThrow();
        }

        [Fact]
        public void ListBox_HaveNoItems_Fail()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ListBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");

            ((Action)(() => c.Should().HaveNoItems())).Should().Throw<XunitException>();
        }

        [Fact]
        public void ListBox_HaveItems_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ListBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveItemsCount(2))).Should().NotThrow();
        }

        [Fact]
        public void ListBox_HaveItems_Fail()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ListBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");
            c.Items.Add("Third Item");

            ((Action)(() => c.Should().HaveItemsCount(2))).Should().Throw<XunitException>();
        }

        [Fact]
        public void ListBox_HaveItem_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ListBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveItemMatching<string>(s => s == "First Item"))).Should().NotThrow();
            ((Action)(() => c.Should().HaveItemMatching<string>(s => s == "Second Item"))).Should().NotThrow();
        }

        [Fact]
        public void ListBox_HaveItem_Fail()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ListBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveItemMatching<string>(s => s == "Third Item"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void ListBox_HaveAllItems_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ListBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveAllItemsMatching<string>(s => s.Contains("Item")))).Should().NotThrow();
        }

        [Fact]
        public void ListBox_HaveAllItems_Fail()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ListBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveAllItemsMatching<string>(s => s.Contains("First")))).Should().Throw<XunitException>();
        }

        [Fact]
        public void ListBox_HaveNoItemsMatching_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ListBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveNotItemsMatching<string>(s => s.Contains("Utem")))).Should().NotThrow();
        }

        [Fact]
        public void ListBox_HaveNoItemsMatching_Fail()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ListBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveNotItemsMatching<string>(s => s.Contains("Item")))).Should().Throw<XunitException>();
        }

        [Fact]
        public void ComboBox_HaveNoItems_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";

            ((Action)(() => c.Should().HaveNoItems())).Should().NotThrow();
        }

        [Fact]
        public void ComboBox_HaveNoItems_Fail()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");

            ((Action)(() => c.Should().HaveNoItems())).Should().Throw<XunitException>();
        }

        [Fact]
        public void ComboBox_HaveItems_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveItemsCount(2))).Should().NotThrow();
        }

        [Fact]
        public void ComboBox_HaveItems_Fail()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");
            c.Items.Add("Third Item");

            ((Action)(() => c.Should().HaveItemsCount(2))).Should().Throw<XunitException>();
        }

        [Fact]
        public void ComboBox_HaveItem_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveItemMatching<string>(s => s == "First Item"))).Should().NotThrow();
            ((Action)(() => c.Should().HaveItemMatching<string>(s => s == "Second Item"))).Should().NotThrow();
        }

        [Fact]
        public void ComboBox_HaveItem_Fail()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveItemMatching<string>(s => s == "Third Item"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void ComboBox_HaveAllItems_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveAllItemsMatching<string>(s => s.Contains("Item")))).Should().NotThrow();
        }

        [Fact]
        public void ComboBox_HaveAllItems_Fail()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveAllItemsMatching<string>(s => s.Contains("First")))).Should().Throw<XunitException>();
        }

        [Fact]
        public void ComboBox_HaveNoItemsMatching_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveNotItemsMatching<string>(s => s.Contains("Utem")))).Should().NotThrow();
        }

        [Fact]
        public void ComboBox_HaveNoItemsMatching_Fail()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<ComboBox>(1, 1, 5, 5);
            c.Name = "tc";
            c.Items.Add("First Item");
            c.Items.Add("Second Item");

            ((Action)(() => c.Should().HaveNotItemsMatching<string>(s => s.Contains("Item")))).Should().Throw<XunitException>();
        }

        [Fact]
        public void Measurement_HaveValue_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Distance;
            c.Value = DistanceUnit.Meter.New(1.5);
            ((Action)(() => c.Should().HaveValue(DistanceUnit.Meter.New(1.5)))).Should().NotThrow();
            ((Action)(() => c.Should().HaveValue(DistanceUnit.Centimeter.New(150)))).Should().NotThrow();
        }

        [Fact]
        public void Measurement_HaveExactValue_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Distance;
            c.Value = DistanceUnit.Meter.New(1.5);
            ((Action)(() => c.Should().HaveExactValue(DistanceUnit.Meter.New(1.5)))).Should().NotThrow();
        }
        [Fact]
        public void Measurement_HaveExactValue_Fail()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Distance;
            c.Value = DistanceUnit.Meter.New(1.5);
            ((Action)(() => c.Should().HaveExactValue(DistanceUnit.Centimeter.New(150)))).Should().Throw<XunitException>();
        }

        [Fact]
        public void Measurement_HaveValue_Fail_Value()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Distance;
            c.Value = DistanceUnit.Meter.New(1.5);
            ((Action)(() => c.Should().HaveValue(DistanceUnit.Meter.New(1.6)))).Should().Throw<XunitException>();
        }

        [Fact]
        public void Measurement_HaveValue_Fail_Type()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Distance;
            c.Value = DistanceUnit.Meter.New(1.5);
            ((Action)(() => c.Should().HaveValue(AngularUnit.CmPer100Meters.New(1.6)))).Should().Throw<XunitException>();
        }

        [Fact]
        public void Measurement_HaveUnitType_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Distance;
            ((Action)(() => c.Should().HaveUnitType(MeasurementType.Distance))).Should().NotThrow();
        }

        [Fact]
        public void Measurement_HaveUnitType_Fail()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Angular;
            ((Action)(() => c.Should().HaveUnitType(MeasurementType.Distance))).Should().Throw<XunitException>();
        }

        [Fact]
        public void Measurement_HaveUnitSelected_OK()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Distance;
            c.Value = DistanceUnit.Meter.New(1.5);
            ((Action)(() => c.Should().HaveUnitSelected(DistanceUnit.Meter))).Should().NotThrow();
        }

        [Fact]
        public void Measurement_HaveUnitSelected_Fail()
        {
            using TestForm tf = new TestForm();
            var c = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 5, 5);
            c.MeasurementType = MeasurementType.Distance;
            c.Value = DistanceUnit.Meter.New(1.5);
            ((Action)(() => c.Should().HaveUnitSelected(DistanceUnit.Centimeter))).Should().Throw<XunitException>();
        }
    }
}
