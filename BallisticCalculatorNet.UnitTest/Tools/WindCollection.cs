using BallisticCalculator;
using BallisticCalculator.Serialization;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.InputPanels;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using Gehtsoft.Measurements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.Tools
{
    public class WindCollectionTest
    {
        [Fact]
        public void InitiallyEmpty()
        {
            var collection = new WindCollection();
            collection.Count.Should().Be(0);
            collection.Should().BeEmpty();
        }

        [Fact]
        public void Add()
        {
            var collection = new WindCollection();
            Wind w0 = new Wind();
            Wind w1 = new Wind();

            collection.Add(w0);
            collection.Add(w1);
            collection.Count.Should().Be(2);
            collection[0].Should().BeSameAs(w0);
            collection[1].Should().BeSameAs(w1);

            collection.Should().ContainInOrder(new Wind[] { w0, w1 });
        }

        [Fact]
        public void Clear()
        {
            var collection = new WindCollection();
            Wind w0 = new Wind();
            Wind w1 = new Wind();

            collection.Add(w0);
            collection.Add(w1);
            collection.Clear();
            collection.Count.Should().Be(0);
        }

        [Fact]
        public void RemoveAt()
        {
            var collection = new WindCollection();
            Wind w0 = new Wind();
            Wind w1 = new Wind();

            collection.Add(w0);
            collection.Add(w1);
            collection.RemoveAt(0);
            collection.Count.Should().Be(1);
            collection[0].Should().BeSameAs(w1);
        }

        [Fact]
        public void GetCollection_Empty()
        {
            var collection = new WindCollection();
            collection.ToShotParameters().Should().BeNull();
        }

        [Fact]
        public void GetCollection_EmptyWind()
        {
            var collection = new WindCollection();
            collection.Add(new Wind());
            collection.ToShotParameters().Should().BeNull();
        }

        [Fact]
        public void GetCollection_OneWind()
        {
            var collection = new WindCollection();
            collection.Add(new Wind(10.As(VelocityUnit.MetersPerSecond), 90.As(AngularUnit.Degree), 0.As(DistanceUnit.Meter)));
            var winds = collection.ToShotParameters();
            winds.Should().HaveCount(1);
            winds[0].MaximumRange.Should().BeNull();
            winds[0].Velocity.Should().Be(10.As(VelocityUnit.MetersPerSecond));
            winds[0].Direction.Should().Be(90.As(AngularUnit.Degree));
        }

        [Fact]
        public void GetCollection_MultipleWindsInOrder()
        {
            var collection = new WindCollection();
            collection.Add(new Wind(10.As(VelocityUnit.MetersPerSecond), 90.As(AngularUnit.Degree), 0.As(DistanceUnit.Meter)));
            collection.Add(new Wind(11.As(VelocityUnit.MetersPerSecond), 91.As(AngularUnit.Degree), 250.As(DistanceUnit.Meter)));
            collection.Add(new Wind(12.As(VelocityUnit.MetersPerSecond), -92.As(AngularUnit.Degree), 500.As(DistanceUnit.Meter)));

            var winds = collection.ToShotParameters();
            winds.Should().HaveCount(3);

            winds[0].MaximumRange.Should().Be(250.As(DistanceUnit.Meter));
            winds[0].Velocity.Should().Be(10.As(VelocityUnit.MetersPerSecond));
            winds[0].Direction.Should().Be(90.As(AngularUnit.Degree));

            winds[1].MaximumRange.Should().Be(500.As(DistanceUnit.Meter));
            winds[1].Velocity.Should().Be(11.As(VelocityUnit.MetersPerSecond));
            winds[1].Direction.Should().Be(91.As(AngularUnit.Degree));

            winds[2].MaximumRange.Should().BeNull();
            winds[2].Velocity.Should().Be(12.As(VelocityUnit.MetersPerSecond));
            winds[2].Direction.Should().Be(-92.As(AngularUnit.Degree));
        }

        [Fact]
        public void GetCollection_MultipleWindsOutOfOrder()
        {
            var collection = new WindCollection();
            collection.Add(new Wind(11.As(VelocityUnit.MetersPerSecond), 91.As(AngularUnit.Degree), 250.As(DistanceUnit.Meter)));
            collection.Add(new Wind(10.As(VelocityUnit.MetersPerSecond), 90.As(AngularUnit.Degree), null));
            collection.Add(new Wind(12.As(VelocityUnit.MetersPerSecond), -92.As(AngularUnit.Degree), 500.As(DistanceUnit.Meter)));

            var winds = collection.ToShotParameters();
            winds.Should().HaveCount(3);

            winds[0].MaximumRange.Should().Be(250.As(DistanceUnit.Meter));
            winds[0].Velocity.Should().Be(10.As(VelocityUnit.MetersPerSecond));
            winds[0].Direction.Should().Be(90.As(AngularUnit.Degree));

            winds[1].MaximumRange.Should().Be(500.As(DistanceUnit.Meter));
            winds[1].Velocity.Should().Be(11.As(VelocityUnit.MetersPerSecond));
            winds[1].Direction.Should().Be(91.As(AngularUnit.Degree));

            winds[2].MaximumRange.Should().BeNull();
            winds[2].Velocity.Should().Be(12.As(VelocityUnit.MetersPerSecond));
            winds[2].Direction.Should().Be(-92.As(AngularUnit.Degree));
        }

        [Fact]
        public void GetCollection_MultipleWindsStartsPastZero()
        {
            var collection = new WindCollection();
            collection.Add(new Wind(11.As(VelocityUnit.MetersPerSecond), 91.As(AngularUnit.Degree), 250.As(DistanceUnit.Meter)));
            collection.Add(new Wind(12.As(VelocityUnit.MetersPerSecond), -92.As(AngularUnit.Degree), 500.As(DistanceUnit.Meter)));

            var winds = collection.ToShotParameters();
            winds.Should().HaveCount(3);

            winds[0].MaximumRange.Should().Be(250.As(DistanceUnit.Meter));
            winds[0].Velocity.Should().Be(0.As(VelocityUnit.MetersPerSecond));
            winds[0].Direction.Should().Be(0.As(AngularUnit.Degree));

            winds[1].MaximumRange.Should().Be(500.As(DistanceUnit.Meter));
            winds[1].Velocity.Should().Be(11.As(VelocityUnit.MetersPerSecond));
            winds[1].Direction.Should().Be(91.As(AngularUnit.Degree));

            winds[2].MaximumRange.Should().BeNull();
            winds[2].Velocity.Should().Be(12.As(VelocityUnit.MetersPerSecond));
            winds[2].Direction.Should().Be(-92.As(AngularUnit.Degree));
        }
    }

    public class ShotDataTest
    {
        public class SerializerRoundtrip
        {
            private readonly BallisticXmlSerializer serializer = new BallisticXmlSerializer();
            private readonly BallisticXmlDeserializer deserializer = new BallisticXmlDeserializer();

            internal XmlElement Serialize(object value) => serializer.Serialize(value);

            internal T Deserialize<T>(XmlElement element) where T : class => deserializer.Deserialize(element, typeof(T)) as T;
        }

        [Fact]
        public void SerializationRoundtrip()
        {
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

            SerializerRoundtrip serializer = new SerializerRoundtrip();
            var xml = serializer.Serialize(data);
            var data1 = serializer.Deserialize<ShotData>(xml);


            //note: we don't need to test serialization in-depth, each type except windcollection is tested
            //in ballisticcalculator library.
            data1.Ammunition.Should().NotBeNull();
            data1.Ammunition.Should().Match<AmmunitionLibraryEntry>(w => w.Name == "" && w.Ammunition.Weight == 8.2.As(WeightUnit.Gram));

            data1.Weapon.Should().NotBeNull();
            data1.Weapon.Should().Match<Rifle>(w => w.Sight != null && w.Sight.SightHeight == 3.2.As(DistanceUnit.Inch));

            data1.Atmosphere.Should().NotBeNull();
            data1.Atmosphere.Should().Match<Atmosphere>(w => w.Altitude == 300.As(DistanceUnit.Foot));

            data1.Wind.Should().NotBeNull()
                .And
                .HaveCount(1);

            data1.Wind[0].Should().Match<Wind>(w => w.Velocity == 10.As(VelocityUnit.MetersPerSecond) &&
                                               w.Direction == 90.As(AngularUnit.Degree) &&
                                               w.MaximumRange == null);

            data1.Parameters.Should().NotBeNull();
            data1.Parameters.Should().Match<ShotParameters>(w => w.MaximumDistance == 1000.As(DistanceUnit.Yard));
        }
    }
}

