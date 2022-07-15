using BallisticCalculator;
using BallisticCalculatorNet.InputPanels;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using Gehtsoft.Measurements;
using Gehtsoft.Winforms.FluentAssertions;
using System;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.InputPanels
{
    public class AmmoLibEntryPanel
    {
        [Fact]
        public void ComboBoxes_Types()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AmmoLibEntryControl>(5, 5, 100, 100);

            var cb = control.ComboBox("comboBoxAmmoType");
            cb.Items.Contains("FMJ").Should().BeTrue();
            cb.Items.Contains("HP").Should().BeTrue();
            cb.Items.Contains("HPBT").Should().BeTrue();
        }

        [Fact]
        public void ComboBoxes_Calibers()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AmmoLibEntryControl>(5, 5, 100, 100);

            var cb = control.ComboBox("comboBoxCaliber");
            cb.Items.Contains(".22 LR").Should().BeTrue();
            cb.Items.Contains("9x19mm").Should().BeTrue();
            cb.Items.Contains(".223 Remington").Should().BeTrue();
        }

        [Fact]
        public void Metric()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AmmoLibEntryControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Metric;

            control.Control("ammoControl").As<AmmoControl>().MeasurementSystem.Should().Be(MeasurementSystem.Metric);
            control.MeasurementControl("measurementBarrelLength").UnitAs<DistanceUnit>().Should().Be(DistanceUnit.Millimeter);
        }

        [Fact]
        public void Imperial()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AmmoLibEntryControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Imperial;

            control.Control("ammoControl").As<AmmoControl>().MeasurementSystem.Should().Be(MeasurementSystem.Imperial);
            control.MeasurementControl("measurementBarrelLength").UnitAs<DistanceUnit>().Should().Be(DistanceUnit.Inch);
        }

        [Fact]
        public void CopyNameForCustomTable()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AmmoLibEntryControl>(5, 5, 100, 100);
            var ammo = control.Control("ammoControl").As<AmmoControl>();

            using var drgFile = TemporaryFile.FromResource("120.drg");
            ammo.CustomBallisticFile = drgFile.FileName;

            control.TextBox("textBoxName").Text.Should().Be("120mm Mortar (McCoy)");
        }

        [Theory]
        [InlineData("ammo")]
        [InlineData("ammox")]
        public void OpenAmmo(string ext)
        {
            using var ammoFile = TemporaryFile.FromResource("762x39rem." + ext, ext);
            var filePrompt = new MockFileNamePrompt() { FileName = ammoFile.FileName };
            var filePropmptFactory = new MockFileNamePromptFactory();
            filePropmptFactory.AddPrompt(filePrompt);

            using TestForm tf = new TestForm();
            var control = tf.AddControl<AmmoLibEntryControl>(5, 5, 100, 100);
            control.PromptFactory = filePropmptFactory;
            control.InvokeEventHandler("buttonLoad_Click", EventArgs.Empty);

            control.TextBox("textBoxName").Text.Should().Be("7.62x39 125gr FMJ");
            control.ComboBox("comboBoxAmmoType").Text.Should().Be("FMJ");
            control.ComboBox("comboBoxCaliber").Text.Should().Be("7.62x39");
            control.TextBox("textBoxSource").Text.Should().Be("Remington");
            control.MeasurementControl("measurementBarrelLength")
                .ValueAsMeasurement<DistanceUnit>().In(DistanceUnit.Inch).Should().BeApproximately(24.0, 1e-8);

            var ammo = control.Control("ammoControl").As<AmmoControl>();

            ammo.MeasurementControl("measurementBulletWeight")
                .ValueAsMeasurement<WeightUnit>().In(WeightUnit.Grain).Should().BeApproximately(125, 1e-8);
            ammo.MeasurementControl("measurementMuzzleVelocity")
                .ValueAsMeasurement<VelocityUnit>().In(VelocityUnit.FeetPerSecond).Should().BeApproximately(2365, 1e-8);
            ammo.MeasurementControl("measurementLength")
                .IsEmpty.Should().BeTrue();
            ammo.MeasurementControl("measurementDiameter")
                .ValueAsMeasurement<DistanceUnit>().In(DistanceUnit.Millimeter).Should().BeApproximately(7.85, 1e-8);

            var bc = ammo.MeasurementControl("measurementBC").ValueAs<BallisticCoefficient>();
            bc.Value.Should().BeApproximately(0.268, 5e-4);
            bc.Table.Should().Be(DragTableId.G1);
            bc.ValueType.Should().Be(BallisticCoefficientValueType.Coefficient);
        }
    }
}
