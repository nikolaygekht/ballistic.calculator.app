using BallisticCalculator;
using BallisticCalculatorNet.InputPanels;
using FluentAssertions;
using Gehtsoft.Measurements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.Utils
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

            collection.Should().ContainInOrder(new Wind[] {w0, w1});
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

            winds[2].MaximumRange.Should().BeNull(); ;
            winds[2].Velocity.Should().Be(12.As(VelocityUnit.MetersPerSecond));
            winds[2].Direction.Should().Be(-92.As(AngularUnit.Degree));
        }
    }
}

