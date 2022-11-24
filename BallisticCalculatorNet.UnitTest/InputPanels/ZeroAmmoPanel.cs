using BallisticCalculator;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.InputPanels;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using Gehtsoft.Measurements;
using Gehtsoft.Winforms.FluentAssertions;
using System;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.InputPanels
{
    public class ZeroAmmoPanel
    {
        [Fact]
        public void Initial()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<ZeroAmmunitionControl>(5, 5, 100, 100);
            control.CheckBox("checkBoxOther").Should().BeNotChecked();
            control.Control("buttonLoad").Should().BeDisabled();
            control.Control("ammoControl").Should().BeDisabled();
            control.Ammunition.Should().BeNull();
        }

        [Fact]
        public void Metric()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<ZeroAmmunitionControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Metric;
            control.Control("ammoControl").As<AmmoControl>().MeasurementSystem.Should().Be(MeasurementSystem.Metric);
        }

        [Fact]
        public void Imperial()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<ZeroAmmunitionControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Imperial;
            control.Control("ammoControl").As<AmmoControl>().MeasurementSystem.Should().Be(MeasurementSystem.Imperial);
        }

        [Fact]
        public void EnableDisable()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<ZeroAmmunitionControl>(5, 5, 100, 100);

            control.CheckBox("checkBoxOther").Checked = true;
            control.InvokeEventHandler("checkBoxOther_CheckedChanged", EventArgs.Empty);
            var ammoControl = control.Control("ammoControl").As<AmmoControl>();
            ammoControl.Should().BeEnabled();
            control.Control("buttonLoad").Should().BeEnabled();
            control.Ammunition.Should().NotBeNull();

            control.CheckBox("checkBoxOther").Checked = false;
            control.InvokeEventHandler("checkBoxOther_CheckedChanged", EventArgs.Empty);
            control.Control("buttonLoad").Should().BeDisabled();
            ammoControl.Should().BeDisabled();
            control.Ammunition.Should().BeNull();
        }

        [Fact]
        public void Load()
        {
            using var ammoFile = TemporaryFile.FromResource("762x39rem.ammo", "ammo");
            var filePrompt = new MockFileNamePrompt() { FileName = ammoFile.FileName };
            var filePropmptFactory = new MockFileNamePromptFactory();
            filePropmptFactory.AddPrompt(filePrompt);
            
            using TestForm tf = new TestForm();
            var control = tf.AddControl<ZeroAmmunitionControl>(5, 5, 100, 100);
            control.PromptFactory = filePropmptFactory;
            control.CheckBox("checkBoxOther").Enabled = true;
            control.InvokeEventHandler("checkBoxOther_CheckedChanged", EventArgs.Empty);
            control.InvokeEventHandler("buttonLoad_Click", EventArgs.Empty);

            var ammo = control.Control("ammoControl").As<AmmoControl>();

            ammo.MeasurementControl("measurementBulletWeight")
                .Value = new Measurement<WeightUnit>(125, WeightUnit.Grain);
            ammo.MeasurementControl("measurementMuzzleVelocity")
                .Value = new Measurement<VelocityUnit>(2365, VelocityUnit.FeetPerSecond);
            ammo.MeasurementControl("measurementDiameter")
                .Value = new Measurement<DistanceUnit>(7.85, DistanceUnit.Millimeter);
            ammo.MeasurementControl("measurementLength")
                .Value = new Measurement<DistanceUnit>(19, DistanceUnit.Millimeter);

            ammo.MeasurementControl("measurementBC")
                .Value = new BallisticCoefficient(0.268, DragTableId.G1);
        }

        [Fact]
        public void NoValue()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<ZeroAmmunitionControl>(5, 5, 100, 100);
            control.Ammunition = null;

            control.CheckBox("checkBoxOther").Should().BeNotChecked();
            control.Control("buttonLoad").Should().BeDisabled();
            control.Control("ammoControl").Should().BeDisabled();

            control.Ammunition.Should().BeNull();
        }

        [Fact]
        public void Value()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<ZeroAmmunitionControl>(5, 5, 100, 100);
            control.Ammunition = new Ammunition(8.As(WeightUnit.Gram), new BallisticCoefficient(0.263, DragTableId.G1), 2300.As(VelocityUnit.FeetPerSecond));

            control.CheckBox("checkBoxOther").Should().BeChecked();
            control.Control("buttonLoad").Should().BeEnabled();
            control.Control("ammoControl").Should().BeEnabled();

            control.Ammunition.Should().NotBeNull();
            control.Ammunition.Weight.Should().Be(8.As(WeightUnit.Gram));
        }
    }
}
