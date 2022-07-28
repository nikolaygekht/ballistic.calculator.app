using BallisticCalculator;
using BallisticCalculatorNet.InputPanels;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using FluentAssertions.Execution;
using Gehtsoft.Measurements;
using Gehtsoft.Winforms.FluentAssertions;
using Moq;
using System;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.InputPanels
{
    public class WeaponPanel
    {
        [Fact]
        public void Defaults()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<WeaponControl>(5, 5, 100, 100);

            control.ComboBox("comboBoxRiflingDirection").Text.Should().Be("Not Set");
            control.ComboBox("comboBoxRiflingDirection").SelectedIndex.Should().Be(0);
            control.MeasurementControl("measurementRifling").Should().BeDisabled();
            control.MeasurementControl("measurementVClick").Value.Should().Be(0.25.As(AngularUnit.MOA));
            control.MeasurementControl("measurementHClick").Value.Should().Be(0.25.As(AngularUnit.MOA));
        }

        [Fact]
        public void Metric()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<WeaponControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Metric;

            control.MeasurementControl("measurementSightHeight").Unit.Should().Be(DistanceUnit.Millimeter);
            control.MeasurementControl("measurementZeroDistance").Unit.Should().Be(DistanceUnit.Meter);
            control.MeasurementControl("measurementRifling").Unit.Should().Be(DistanceUnit.Millimeter);
        }

        [Fact]
        public void Imperial()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<WeaponControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Imperial;

            control.MeasurementControl("measurementSightHeight").Unit.Should().Be(DistanceUnit.Inch);
            control.MeasurementControl("measurementZeroDistance").Unit.Should().Be(DistanceUnit.Yard);
            control.MeasurementControl("measurementRifling").Unit.Should().Be(DistanceUnit.Inch);
        }

        [Fact]
        public void RiflingSelector()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<WeaponControl>(5, 5, 100, 100);

            control.MeasurementControl("measurementRifling").Value = 8.As(DistanceUnit.Inch);

            control.ComboBox("comboBoxRiflingDirection").SelectedIndex = 1;
            control.InvokeEventHandler("comboBoxRiflingDirection_SelectedIndexChanged", EventArgs.Empty);
            control.MeasurementControl("measurementRifling").Should().BeEnabled();
            control.Rifle.Rifling.Should().NotBeNull();
            control.Rifle.Rifling.Direction.Should().Be(TwistDirection.Left);

            control.ComboBox("comboBoxRiflingDirection").SelectedIndex = 0;
            control.InvokeEventHandler("comboBoxRiflingDirection_SelectedIndexChanged", EventArgs.Empty);
            control.MeasurementControl("measurementRifling").Should().BeDisabled();
            control.Rifle.Rifling.Should().BeNull();

            control.ComboBox("comboBoxRiflingDirection").SelectedIndex = 2;
            control.InvokeEventHandler("comboBoxRiflingDirection_SelectedIndexChanged", EventArgs.Empty);
            control.MeasurementControl("measurementRifling").Should().BeEnabled();
            control.Rifle.Rifling.Should().NotBeNull();
            control.Rifle.Rifling.Direction.Should().Be(TwistDirection.Right);
        }

        [Fact]
        public void Get()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<WeaponControl>(5, 5, 100, 100);

            control.MeasurementControl("measurementSightHeight").Value = 3.5.As(DistanceUnit.Inch);
            control.MeasurementControl("measurementZeroDistance").Value = 100.As(DistanceUnit.Yard);
            control.ComboBox("comboBoxRiflingDirection").SelectedIndex = 2;
            control.MeasurementControl("measurementRifling").Value = 8.As(DistanceUnit.Inch);
            control.MeasurementControl("measurementVClick").Value = 0.1.As(AngularUnit.Mil);
            control.MeasurementControl("measurementHClick").Value = 0.2.As(AngularUnit.Mil);

            var rifle = control.Rifle;

            rifle.Sight.Should().NotBeNull();
            rifle.Sight.SightHeight.Should().Be(3.5.As(DistanceUnit.Inch));
            rifle.Sight.VerticalClick.Should().Be(0.1.As(AngularUnit.Mil));
            rifle.Sight.HorizontalClick.Should().Be(0.2.As(AngularUnit.Mil));

            rifle.Rifling.Should().NotBeNull();
            rifle.Rifling.Direction.Should().Be(TwistDirection.Right);
            rifle.Rifling.RiflingStep.Should().Be(8.As(DistanceUnit.Inch));

            rifle.Zero.Should().NotBeNull();
            rifle.Zero.Distance.Should().Be(100.As(DistanceUnit.Yard));
            rifle.Zero.Ammunition.Should().BeNull();
            rifle.Zero.Atmosphere.Should().BeNull();
        }

        [Fact]
        public void SetNull_Metric()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<WeaponControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Metric;

            control.Rifle = null;

            control.MeasurementControl("measurementSightHeight").Value.Should().Be(50.As(DistanceUnit.Millimeter));
            control.MeasurementControl("measurementZeroDistance").Value.Should().Be(100.As(DistanceUnit.Meter));
            control.ComboBox("comboBoxRiflingDirection").SelectedIndex.Should().Be(0);
            control.MeasurementControl("measurementRifling").Should().BeDisabled();
            control.MeasurementControl("measurementVClick").Value.Should().Be(0.25.As(AngularUnit.MOA));
            control.MeasurementControl("measurementHClick").Value.Should().Be(0.25.As(AngularUnit.MOA));
        }

        [Fact]
        public void SetNull_Imperial()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<WeaponControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Imperial;

            control.Rifle = null;

            control.MeasurementControl("measurementSightHeight").Value.Should().Be(2.6.As(DistanceUnit.Inch));
            control.MeasurementControl("measurementZeroDistance").Value.Should().Be(25.As(DistanceUnit.Yard));
            control.ComboBox("comboBoxRiflingDirection").SelectedIndex.Should().Be(0);
            control.MeasurementControl("measurementRifling").Should().BeDisabled();
            control.MeasurementControl("measurementVClick").Value.Should().Be(0.25.As(AngularUnit.MOA));
            control.MeasurementControl("measurementHClick").Value.Should().Be(0.25.As(AngularUnit.MOA));
        }

        [Fact]
        public void Set()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<WeaponControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Imperial;

            control.Rifle = new Rifle()
            {
                Sight = new Sight()
                {
                    SightHeight = 3.2.As(DistanceUnit.Inch),
                    VerticalClick = 0.1.As(AngularUnit.Mil),
                    HorizontalClick = 0.2.As(AngularUnit.Mil)
                },
                Rifling = new Rifling()
                {
                    Direction = TwistDirection.Right,
                    RiflingStep = 12.As(DistanceUnit.Inch)
                },
                Zero = new ZeroingParameters()
                {
                    Distance = 300.As(DistanceUnit.Yard)
                }
            };

            control.MeasurementControl("measurementSightHeight").Value.Should().Be(3.2.As(DistanceUnit.Inch));
            control.MeasurementControl("measurementZeroDistance").Value.Should().Be(300.As(DistanceUnit.Yard));
            control.ComboBox("comboBoxRiflingDirection").SelectedIndex.Should().Be(2);
            control.MeasurementControl("measurementRifling").Should().BeEnabled();
            control.MeasurementControl("measurementRifling").Value.Should().Be(12.As(DistanceUnit.Inch));
            control.MeasurementControl("measurementVClick").Value.Should().Be(0.1.As(AngularUnit.Mil));
            control.MeasurementControl("measurementHClick").Value.Should().Be(0.2.As(AngularUnit.Mil));
        }

        [Theory]
        [InlineData(MeasurementSystem.Metric)]
        [InlineData(MeasurementSystem.Imperial)]
        public void PropogateMeasurementSystem_ToZerocontrols(MeasurementSystem ms)
        {
            var zeroAmmo = new Mock<IZeroAmmunitionControl>();
            zeroAmmo.SetupSet(v => v.MeasurementSystem = ms).Verifiable();

            var zeroAtmo = new Mock<IZeroAtmosphereControl>();
            zeroAtmo.SetupSet(v => v.MeasurementSystem = ms).Verifiable();

            using TestForm tf = new TestForm();
            var control = tf.AddControl<WeaponControl>(5, 5, 100, 100);

            control.ZeroAmmunition = zeroAmmo.Object;
            control.ZeroAtmosphere = zeroAtmo.Object;

            control.MeasurementSystem = ms;

            zeroAmmo.Verify();
            zeroAtmo.Verify();
        }

        [Fact]
        public void PropogateValues_ToZerocontrols()
        {
            var ammo = new Ammunition(8.As(WeightUnit.Gram), new BallisticCoefficient(0.263, DragTableId.G1), 2300.As(VelocityUnit.FeetPerSecond));
            var atmo = new Atmosphere();
            var weapon = new Rifle()
            {
                Zero = new ZeroingParameters()
                {
                    Distance = 100.As(DistanceUnit.Yard),
                    Ammunition = ammo,
                    Atmosphere = atmo,
                }
            };

            var zeroAmmo = new Mock<IZeroAmmunitionControl>();
            zeroAmmo.SetupSet(v => v.Ammunition = ammo).Verifiable();

            var zeroAtmo = new Mock<IZeroAtmosphereControl>();
            zeroAtmo.SetupSet(v => v.Atmosphere = atmo).Verifiable();

            using TestForm tf = new TestForm();
            var control = tf.AddControl<WeaponControl>(5, 5, 100, 100);

            control.ZeroAmmunition = zeroAmmo.Object;
            control.ZeroAtmosphere = zeroAtmo.Object;

            control.Rifle = weapon;

            zeroAmmo.Verify();
            zeroAtmo.Verify();
        }

        [Fact]
        public void PropogateNull_ToZerocontrols()
        {
            var weapon = new Rifle()
            {
                Zero = new ZeroingParameters()
                {
                    Distance = 100.As(DistanceUnit.Yard),
                }
            };

            var zeroAmmo = new Mock<IZeroAmmunitionControl>();
            zeroAmmo.SetupSet(v => v.Ammunition = null).Verifiable();

            var zeroAtmo = new Mock<IZeroAtmosphereControl>();
            zeroAtmo.SetupSet(v => v.Atmosphere = null).Verifiable();

            using TestForm tf = new TestForm();
            var control = tf.AddControl<WeaponControl>(5, 5, 100, 100);

            control.ZeroAmmunition = zeroAmmo.Object;
            control.ZeroAtmosphere = zeroAtmo.Object;

            control.Rifle = weapon;

            zeroAmmo.Verify();
            zeroAtmo.Verify();
        }

        [Fact]
        public void GatherValues_FromZerocontrols()
        {
            var ammo = new Ammunition(8.As(WeightUnit.Gram), new BallisticCoefficient(0.263, DragTableId.G1), 2300.As(VelocityUnit.FeetPerSecond));
            var atmo = new Atmosphere();

            var zeroAmmo = new Mock<IZeroAmmunitionControl>();
            zeroAmmo.Setup(v => v.Ammunition).Returns(ammo);

            var zeroAtmo = new Mock<IZeroAtmosphereControl>();
            zeroAtmo.Setup(v => v.Atmosphere).Returns(atmo);

            using TestForm tf = new TestForm();
            var control = tf.AddControl<WeaponControl>(5, 5, 100, 100);

            control.ZeroAmmunition = zeroAmmo.Object;
            control.ZeroAtmosphere = zeroAtmo.Object;

            var weapon = control.Rifle;

            weapon.Zero?.Atmosphere.Should().NotBeNull();
            weapon.Zero?.Ammunition.Should().NotBeNull();

            weapon.Zero?.Ammunition?.Weight.Should().Be(8.As(WeightUnit.Gram));
            weapon.Zero?.Atmosphere?.Temperature.Should().Be(59.As(TemperatureUnit.Fahrenheit));
        }
    }
}
