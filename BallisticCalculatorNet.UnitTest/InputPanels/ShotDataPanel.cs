using BallisticCalculator;
using BallisticCalculatorNet.Types;
using BallisticCalculatorNet.InputPanels;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using Gehtsoft.Measurements;
using Gehtsoft.Winforms.FluentAssertions;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.InputPanels
{
    public class ShotDataPanel
    {
        [Fact]
        public void MeasurementSystemPropagation()
        {
            using TestForm tf = new TestForm();
            var control = tf.AddControl<ShotDataControl>(5, 5, 100, 100);
            control.MeasurementSystem = MeasurementSystem.Imperial;
            control.Control<AmmoLibEntryControl>("panelShotAmmo").MeasurementSystem.Should().Be(MeasurementSystem.Imperial);
            control.Control<AtmosphereControl>("panelShotWeather").MeasurementSystem.Should().Be(MeasurementSystem.Imperial);
            control.Control<WeaponControl>("panelWeapon").MeasurementSystem.Should().Be(MeasurementSystem.Imperial);
            control.Control<ZeroAmmunitionControl>("panelZeroAmmo").MeasurementSystem.Should().Be(MeasurementSystem.Imperial);
            control.Control<ZeroAtmosphereControl>("panelZeroWeather").MeasurementSystem.Should().Be(MeasurementSystem.Imperial);
            control.Control<ParametersControl>("panelParameters").MeasurementSystem.Should().Be(MeasurementSystem.Imperial);
        }

        [Fact]
        public void DataPropagation_NoZeroParams()
        {
            //we check only that the data is propagated back and forth.
            //complete test of very single field is
            //already done per each panel.

            using TestForm tf = new TestForm();
            var control = tf.AddControl<ShotDataControl>(5, 5, 100, 100);

            var data = new ShotData()
            {
                Ammunition = new AmmunitionLibraryEntry()
                {
                    Name = "",
                    Ammunition = new Ammunition(8.2.As(WeightUnit.Gram), new BallisticCoefficient(0.208, DragTableId.G1),
                                                980.As(VelocityUnit.MetersPerSecond))
                },
                Weapon = new Rifle(new Sight(3.2.As(DistanceUnit.Inch), 0.25.As(AngularUnit.MOA), 0.25.As(AngularUnit.MOA)),
                                   new ZeroingParameters() { Distance = 100.As(DistanceUnit.Yard) },
                                   new Rifling() { Direction = TwistDirection.Right, RiflingStep = 12.As(DistanceUnit.Inch) }),
                Atmosphere = new Atmosphere(300.As(DistanceUnit.Foot), 30.02.As(PressureUnit.InchesOfMercury),
                                            80.As(TemperatureUnit.Fahrenheit), 0.91),
                Wind = new WindCollection() { new Wind(10.As(VelocityUnit.MetersPerSecond), 90.As(AngularUnit.Degree)) },
                Parameters = new ShotParameters()
                {
                    MaximumDistance = 1000.As(DistanceUnit.Yard),
                    Step = 100.As(DistanceUnit.Yard),
                },
            };

            control.ShotData = data;

            control.Control<AmmoLibEntryControl>("panelShotAmmo")
                .Ammunition.Weight.Should().Be(8.2.As(WeightUnit.Gram));


            control.Control<AtmosphereControl>("panelShotWeather")
                .Atmosphere.Altitude.Should().Be(300.As(DistanceUnit.Foot));

            control.Control<WeaponControl>("panelWeapon")
                .Rifle.Sight.SightHeight.Should().Be(3.2.As(DistanceUnit.Inch));
            
           
            control.Control<ZeroAmmunitionControl>("panelZeroAmmo")
                .Ammunition.Should().BeNull();
            
            control.Control<ZeroAtmosphereControl>("panelZeroWeather")
                .Atmosphere.Should().BeNull();

            control.Control<ParametersControl>("panelParameters")
                .Parameters.MaximumDistance.Should().Be(1000.As(DistanceUnit.Yard));


            var data1 = control.ShotData;

            data1.Ammunition.Ammunition.Weight.Should().Be(8.2.As(WeightUnit.Gram));


            data1.Atmosphere.Altitude.Should().Be(300.As(DistanceUnit.Foot));

            data1.Weapon.Sight.SightHeight.Should().Be(3.2.As(DistanceUnit.Inch));


            data1.Weapon.Zero.Ammunition.Should().BeNull();
            data1.Weapon.Zero.Atmosphere.Should().BeNull();

            data1.Parameters.MaximumDistance.Should().Be(1000.As(DistanceUnit.Yard));
        }

        [Fact]
        public void DataPropagation_ZeroParams()
        {
            //we check only that the data is propagated back and forth.
            //complete test of very single field is
            //already done per each panel.

            using TestForm tf = new TestForm();
            var control = tf.AddControl<ShotDataControl>(5, 5, 100, 100);

            var data = new ShotData()
            {
                Ammunition = new AmmunitionLibraryEntry()
                {
                    Name = "",
                    Ammunition = new Ammunition(8.2.As(WeightUnit.Gram), new BallisticCoefficient(0.208, DragTableId.G1),
                                                980.As(VelocityUnit.MetersPerSecond))
                },
                Weapon = new Rifle(new Sight(3.2.As(DistanceUnit.Inch), 0.25.As(AngularUnit.MOA), 0.25.As(AngularUnit.MOA)),
                                   new ZeroingParameters() { Distance = 100.As(DistanceUnit.Yard),
                                                             Ammunition = new Ammunition(9.1.As(WeightUnit.Gram), new BallisticCoefficient(0.215, DragTableId.G1),
                                                                                         1020.As(VelocityUnit.MetersPerSecond)),
                                                             Atmosphere = new Atmosphere(),
                                   },
                                   new Rifling() { Direction = TwistDirection.Right, RiflingStep = 12.As(DistanceUnit.Inch) }),
                Atmosphere = new Atmosphere(300.As(DistanceUnit.Foot), 30.02.As(PressureUnit.InchesOfMercury),
                                            80.As(TemperatureUnit.Fahrenheit), 0.91),
                Wind = new WindCollection() { new Wind(10.As(VelocityUnit.MetersPerSecond), 90.As(AngularUnit.Degree)) },
                Parameters = new ShotParameters()
                {
                    MaximumDistance = 1000.As(DistanceUnit.Yard),
                    Step = 100.As(DistanceUnit.Yard),
                },
            };

            control.ShotData = data;

            control.Control<ZeroAmmunitionControl>("panelZeroAmmo")
                .Ammunition.Should().NotBeNull();

            control.Control<ZeroAtmosphereControl>("panelZeroWeather")
                .Atmosphere.Should().NotBeNull();

            var data1 = control.ShotData;

            data1.Weapon.Zero.Ammunition.Weight.Should().Be(9.1.As(WeightUnit.Gram));
            data1.Weapon.Zero.Atmosphere.Temperature.Should().Be(59.As(TemperatureUnit.Fahrenheit));
        }
    }
}

