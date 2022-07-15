using BallisticCalculator;
using BallisticCalculatorNet.InputPanels;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using Gehtsoft.Measurements;
using Gehtsoft.Winforms.FluentAssertions;
using System;
using System.IO;
using System.Security.Policy;
using System.Windows.Forms;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.InputPanels
{
    public class AmmoPanel
    {
        [Fact]
        public void Metric()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AmmoControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Metric;
            control.MeasurementControl("measurementBulletWeight").UnitAs<WeightUnit>().Should().Be(WeightUnit.Gram);
            control.MeasurementControl("measurementBulletWeight").DecimalPoints.Should().Be(2);

            control.MeasurementControl("measurementMuzzleVelocity").UnitAs<VelocityUnit>().Should().Be(VelocityUnit.MetersPerSecond);
            control.MeasurementControl("measurementMuzzleVelocity").DecimalPoints.Should().Be(1);

            control.MeasurementControl("measurementLength").UnitAs<DistanceUnit>().Should().Be(DistanceUnit.Millimeter);
            control.MeasurementControl("measurementLength").DecimalPoints.Should().Be(2);

            control.MeasurementControl("measurementDiameter").UnitAs<DistanceUnit>().Should().Be(DistanceUnit.Millimeter);
            control.MeasurementControl("measurementDiameter").DecimalPoints.Should().Be(2);
        }

        [Fact]
        public void Imperial()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AmmoControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Imperial;
            
            control.MeasurementControl("measurementBulletWeight").UnitAs<WeightUnit>().Should().Be(WeightUnit.Grain);
            control.MeasurementControl("measurementBulletWeight").DecimalPoints.Should().Be(1);

            control.MeasurementControl("measurementMuzzleVelocity").UnitAs<VelocityUnit>().Should().Be(VelocityUnit.FeetPerSecond);
            control.MeasurementControl("measurementMuzzleVelocity").DecimalPoints.Should().Be(1);

            control.MeasurementControl("measurementLength").UnitAs<DistanceUnit>().Should().Be(DistanceUnit.Inch);
            control.MeasurementControl("measurementLength").DecimalPoints.Should().Be(3);

            control.MeasurementControl("measurementDiameter").UnitAs<DistanceUnit>().Should().Be(DistanceUnit.Inch);
            control.MeasurementControl("measurementDiameter").DecimalPoints.Should().Be(3);
        }

        [Theory]
        [InlineData("7.7g", "930m/s", "0.297G1", "26mm", "7.85mm")]
        [InlineData("7.7g", "930m/s", "F1.5G1", "26mm", "7.85mm")]
        [InlineData("7.7g", "930m/s", "0.297GC", "26mm", "7.85mm")]
        [InlineData("155gr", "2850ft/s", "0.216G7", "1.218in", "0.308in")]
        [InlineData("155gr", "2850ft/s", "0.216G7", "", "0.308in")]
        [InlineData("155gr", "2850ft/s", "0.216G7", "", "")]
        public void Set(string weight, string velocity, string bc, string length, string diameter)
        {
            Ammunition ammo = new Ammunition()
            {
                Weight = new Measurement<WeightUnit>(weight),
                BallisticCoefficient = new BallisticCoefficient(bc),
                MuzzleVelocity = new Measurement<VelocityUnit>(velocity),
                BulletDiameter = !string.IsNullOrEmpty(diameter) ? new Measurement<DistanceUnit>(diameter) : null,
                BulletLength = !string.IsNullOrEmpty(length) ? new Measurement<DistanceUnit>(length) : null,
            };

            using TestForm tf = new TestForm();
            var control = tf.AddControl<AmmoControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Imperial;
            
            control.Ammunition = ammo;

            control.MeasurementControl("measurementBulletWeight").Value.Should().Be(ammo.Weight);
            control.MeasurementControl("measurementBC").Value.Should().Be(ammo.BallisticCoefficient);
            control.MeasurementControl("measurementMuzzleVelocity").Value.Should().Be(ammo.MuzzleVelocity);
            if (ammo.BulletLength == null)
                control.MeasurementControl("measurementLength").IsEmpty.Should().BeTrue();
            else
                control.MeasurementControl("measurementLength").Value.Should().Be(ammo.BulletLength);

            if (ammo.BulletDiameter == null)
                control.MeasurementControl("measurementDiameter").IsEmpty.Should().BeTrue();
            else
                control.MeasurementControl("measurementDiameter").Value.Should().Be(ammo.BulletDiameter);

            control.CheckBox("checkBoxFormFactor").Checked.Should().Be(ammo.BallisticCoefficient.ValueType == BallisticCoefficientValueType.FormFactor);

            Ammunition ammo1 = control.Ammunition;

            ammo1.Should().NotBeSameAs(ammo);

            ammo1.Weight.Should().Be(ammo.Weight);
            ammo1.BallisticCoefficient.Should().Be(ammo.BallisticCoefficient);
            ammo1.MuzzleVelocity.Should().Be(ammo.MuzzleVelocity);
            ammo1.BulletDiameter.Should().Be(ammo.BulletDiameter);
            ammo1.BulletLength.Should().Be(ammo.BulletLength);
           
        }

        private const string DRG = "BRL, 120mm Mortar(McCoy), 13.585, 0.11956, 0.7049, Radar Data\r\n" +
                                 "0.119\t0\r\n" +
                                 "0.119\t0.7\r\n" +
                                 "0.12\t0.85\r\n" +
                                 "0.122\t0.87\r\n" +
                                 "0.126\t0.9\r\n" +
                                 "0.148\t0.93\r\n" +
                                 "0.182\t0.95\r\n";


        [Fact]
        public void SetDrgFile()
        {
            var fileName = Path.GetTempFileName();
            File.WriteAllText(fileName, DRG);
            using var defer = Defer.Action(() => File.Delete(fileName));
            using TestForm tf = new TestForm();
            var control = tf.AddControl<AmmoControl>(5, 5, 100, 100);
            control.CustomBallisticFile = fileName;           
            control.CustomBallistic.Should().NotBeNull();

            var ammo = control.Ammunition;
            var bc = ammo.BallisticCoefficient;
            bc.Table.Should().Be(DragTableId.GC);
            bc.Value.Should().BeApproximately(1, 5e-5);
            bc.ValueType.Should().Be(BallisticCoefficientValueType.FormFactor);

            ammo.Weight.In(WeightUnit.Gram).Should().BeApproximately(13585, 5e-3);
            ammo.BulletDiameter.Value.Should().NotBeNull();
            ammo.BulletDiameter.Value.In(DistanceUnit.Millimeter).Should().BeApproximately(119.56, 5e-3);

            control.InvokeEventHandler("buttonSDasBC_Click", EventArgs.Empty);

            ammo = control.Ammunition;
            bc = ammo.BallisticCoefficient;
            bc.Table.Should().Be(DragTableId.GC);
            bc.Value.Should().BeApproximately(1.3517, 5e-5);
            bc.ValueType.Should().Be(BallisticCoefficientValueType.Coefficient);
        }
    }
}
