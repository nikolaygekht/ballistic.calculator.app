using BallisticCalculator;
using BallisticCalculator.Data.Dictionary;
using BallisticCalculator.Serialization;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.InputPanels;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using Gehtsoft.Measurements;
using Gehtsoft.Winforms.FluentAssertions;
using Moq;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

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
            control.TextBox("textBoxCaliber").Text.Should().Be("7.62x39");
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

        [Fact]
        public void Collect_Full()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AmmoLibEntryControl>(5, 5, 100, 100);

            control.TextBox("textBoxName").Text = "7.62x39 125gr FMJ";
            control.ComboBox("comboBoxAmmoType").Text = "FMJ";
            control.TextBox("textBoxCaliber").Text = "7.62x39";
            control.TextBox("textBoxSource").Text = "Remington";
            control.MeasurementControl("measurementBarrelLength")
                .Value = new Measurement<DistanceUnit>(24, DistanceUnit.Inch);

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

            var libEntry = control.LibraryEntry;

            libEntry.Name.Should().Be("7.62x39 125gr FMJ");
            libEntry.Source.Should().Be("Remington");
            libEntry.AmmunitionType.Should().Be("FMJ");
            libEntry.Caliber.Should().Be("7.62x39");
            libEntry.BarrelLength.Should().NotBeNull();
            libEntry.BarrelLength.Value.In(DistanceUnit.Inch).Should().BeApproximately(24.0, 1e-8);

            libEntry.Ammunition.BallisticCoefficient.Value.Should().BeApproximately(0.268, 5e-5);
            libEntry.Ammunition.BallisticCoefficient.Table.Should().Be(DragTableId.G1);
            libEntry.Ammunition.BallisticCoefficient.ValueType.Should().Be(BallisticCoefficientValueType.Coefficient);
            libEntry.Ammunition.MuzzleVelocity.In(VelocityUnit.FeetPerSecond).Should().BeApproximately(2365, 5e-5);
            libEntry.Ammunition.Weight.In(WeightUnit.Grain).Should().BeApproximately(125, 5e-5);
            libEntry.Ammunition.BulletDiameter.Should().NotBeNull();
            libEntry.Ammunition.BulletDiameter.Value.In(DistanceUnit.Millimeter).Should().BeApproximately(7.85, 5e-5);
            libEntry.Ammunition.BulletLength.Should().NotBeNull();
            libEntry.Ammunition.BulletLength.Value.In(DistanceUnit.Millimeter).Should().BeApproximately(19, 5e-5);
        }

        [Fact]
        public void Collect_Minimum()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AmmoLibEntryControl>(5, 5, 100, 100);

            var ammo = control.Control("ammoControl").As<AmmoControl>();

            ammo.MeasurementControl("measurementBulletWeight")
                .Value = new Measurement<WeightUnit>(125, WeightUnit.Grain);
            ammo.MeasurementControl("measurementMuzzleVelocity")
                .Value = new Measurement<VelocityUnit>(2365, VelocityUnit.FeetPerSecond);

            ammo.MeasurementControl("measurementBC")
                .Value = new BallisticCoefficient(0.268, DragTableId.G1);

            var libEntry = control.LibraryEntry;

            libEntry.Name.Should().BeEmpty();
            libEntry.Source.Should().BeEmpty();
            libEntry.AmmunitionType.Should().BeEmpty();
            libEntry.Caliber.Should().BeEmpty();
            libEntry.BarrelLength.Should().BeNull();

            libEntry.Ammunition.BallisticCoefficient.Value.Should().BeApproximately(0.268, 5e-5);
            libEntry.Ammunition.BallisticCoefficient.Table.Should().Be(DragTableId.G1);
            libEntry.Ammunition.BallisticCoefficient.ValueType.Should().Be(BallisticCoefficientValueType.Coefficient);
            libEntry.Ammunition.MuzzleVelocity.In(VelocityUnit.FeetPerSecond).Should().BeApproximately(2365, 5e-5);
            libEntry.Ammunition.Weight.In(WeightUnit.Grain).Should().BeApproximately(125, 5e-5);

            libEntry.Ammunition.BulletDiameter.Should().BeNull();
            libEntry.Ammunition.BulletLength.Should().BeNull();
        }

        [Fact]
        public void Write()
        {
            using var ammoFile = TemporaryFile.WithExtension("ammox");

            var filePrompt = new MockFileNamePrompt() { FileName = ammoFile.FileName };
            var filePropmptFactory = new MockFileNamePromptFactory();
            filePropmptFactory.AddPrompt(filePrompt);

            using TestForm tf = new TestForm();
            var control = tf.AddControl<AmmoLibEntryControl>(5, 5, 100, 100);
            control.PromptFactory = filePropmptFactory;

            control.TextBox("textBoxName").Text = "7.62x39 125gr FMJ";
            control.ComboBox("comboBoxAmmoType").Text = "FMJ";
            control.TextBox("textBoxCaliber").Text = "7.62x39";
            control.TextBox("textBoxSource").Text = "Remington";
            control.MeasurementControl("measurementBarrelLength")
                .Value = new Measurement<DistanceUnit>(24, DistanceUnit.Inch);

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

            control.InvokeEventHandler("buttonSave_Click", EventArgs.Empty);
            File.Exists(ammoFile.FileName).Should().BeTrue();


            AmmunitionLibraryEntry libEntry = default;

            ((Action)(() => libEntry = BallisticXmlDeserializer.ReadFromFile<AmmunitionLibraryEntry>(ammoFile.FileName))).Should().NotThrow();
            libEntry.Should().NotBeNull();

            libEntry.Name.Should().Be("7.62x39 125gr FMJ");
            libEntry.Source.Should().Be("Remington");
            libEntry.AmmunitionType.Should().Be("FMJ");
            libEntry.Caliber.Should().Be("7.62x39");
            libEntry.BarrelLength.Should().NotBeNull();
            libEntry.BarrelLength.Value.In(DistanceUnit.Inch).Should().BeApproximately(24.0, 1e-8);

            libEntry.Ammunition.BallisticCoefficient.Value.Should().BeApproximately(0.268, 5e-5);
            libEntry.Ammunition.BallisticCoefficient.Table.Should().Be(DragTableId.G1);
            libEntry.Ammunition.BallisticCoefficient.ValueType.Should().Be(BallisticCoefficientValueType.Coefficient);
            libEntry.Ammunition.MuzzleVelocity.In(VelocityUnit.FeetPerSecond).Should().BeApproximately(2365, 5e-5);
            libEntry.Ammunition.Weight.In(WeightUnit.Grain).Should().BeApproximately(125, 5e-5);
            libEntry.Ammunition.BulletDiameter.Should().NotBeNull();
            libEntry.Ammunition.BulletDiameter.Value.In(DistanceUnit.Millimeter).Should().BeApproximately(7.85, 5e-5);
            libEntry.Ammunition.BulletLength.Should().NotBeNull();
            libEntry.Ammunition.BulletLength.Value.In(DistanceUnit.Millimeter).Should().BeApproximately(19, 5e-5);
        }

        [Fact]
        public void UseCaliberLibrary()
        {
            var caliber = new AmmunitionCaliber(AmmunitionCaliberType.Pistol, null, 7.62.As(DistanceUnit.Millimeter), "7.62x39mm", "");

            var caliberForm = new Mock<ICaliberSelector>();
            caliberForm.Setup(f => f.Caliber).Returns(caliber);
            caliberForm.Setup(f => f.Select(It.IsAny<IWin32Window>())).Returns(true);

            var caliberFactory = new Mock<ICaliberSelectorFactory>();
            caliberFactory.Setup(f => f.Create()).Returns(caliberForm.Object);


            using TestForm tf = new TestForm();
            var control = tf.AddControl<AmmoLibEntryControl>(5, 5, 100, 100);
            control.CaliberSelectorFactory = caliberFactory.Object;

            control.InvokeEventHandler("buttonCaliberSelect_Click", EventArgs.Empty);

            control.TextBox("textBoxCaliber").Should().HaveText("7.62x39mm");

            control.Control("ammoControl")
                .MeasurementControl("measurementDiameter")
                .Should().HaveValue(7.62.As(DistanceUnit.Millimeter));
        }
    }
}
