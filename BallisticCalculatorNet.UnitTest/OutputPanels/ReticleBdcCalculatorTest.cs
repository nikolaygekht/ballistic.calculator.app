using BallisticCalculator;
using BallisticCalculatorNet.InputPanels;
using FluentAssertions;
using Gehtsoft.Winforms.FluentAssertions;
using Gehtsoft.Measurements;
using System;
using Xunit;
using BallisticCalculator.Reticle.Data;
using BallisticCalculatorNet.UnitTest.Tools;
using BallisticCalculator.Reticle;

namespace BallisticCalculatorNet.UnitTest.OutputPanels
{
    public class ReticleBdcCalculatorTest
    {
        [Theory]
        //zoom 1, second point exact match
        [InlineData(50, -5, 100, -10, 1, 100, TrajectoryToReticleCalculator.PointLocation.Far)]
        //zoom 1, first point exact match
        [InlineData(50, -10, 100, -15, 1, 50, TrajectoryToReticleCalculator.PointLocation.Near)]
        //zoom 1, in the middle between point
        [InlineData(50, -5, 100, -15, 1, 75, TrajectoryToReticleCalculator.PointLocation.Near)]
        //zoom 1, shifted to the left
        [InlineData(50, -5, 100, -25, 1, 62.5, TrajectoryToReticleCalculator.PointLocation.Near)]
        //zoom 1, shifted to the right
        [InlineData(150, -5, 200, -11, 1, 191.67, TrajectoryToReticleCalculator.PointLocation.Far)]
        //zoom 2, shifted to the right
        [InlineData(150, -10, 200, -22, 2, 191.67, TrajectoryToReticleCalculator.PointLocation.Far)]
        public void PointCalculation(double range1, double dropAdjustment1,
                                     double range2, double dropAdjustment2,
                                     double zoom,
                                     double calculatedRange,
                                     TrajectoryToReticleCalculator.PointLocation location)
        {
            var drop1 = dropAdjustment1 * (range1 / 100);
            var drop2 = dropAdjustment2 * (range2 / 100);

            var bdc = new ReticleBulletDropCompensatorPointCollection()
            {
                new ReticleBulletDropCompensatorPoint()
                {
                    Position = new ReticlePosition(0.As(AngularUnit.CmPer100Meters), -10.As(AngularUnit.CmPer100Meters))
                }
            };


            var trajectory = new[]
            {
                new TrajectoryPoint(TimeSpan.FromSeconds(0),
                                    10.As(WeightUnit.Gram),
                                    0.As(DistanceUnit.Meter),
                                    1000.As(VelocityUnit.MetersPerSecond), 1,
                                    0.As(DistanceUnit.Centimeter), 0.As(DistanceUnit.Centimeter)),      //first point is ignored
            
                new TrajectoryPoint(TimeSpan.FromSeconds(1),
                                    10.As(WeightUnit.Gram),
                                    range1.As(DistanceUnit.Meter),
                                    1000.As(VelocityUnit.MetersPerSecond), 1,
                                    drop1.As(DistanceUnit.Centimeter), 0.As(DistanceUnit.Centimeter)),

                new TrajectoryPoint(TimeSpan.FromSeconds(1),
                                    10.As(WeightUnit.Gram),
                                    range2.As(DistanceUnit.Meter),
                                    1000.As(VelocityUnit.MetersPerSecond), 1,
                                    drop2.As(DistanceUnit.Centimeter), 0.As(DistanceUnit.Centimeter))
            };


            var calculator = new TrajectoryToReticleCalculator(trajectory, bdc, 100.As(DistanceUnit.Meter));
            calculator.UpdatePoints(zoom);

            calculator.Points.Should().HaveCount(1);
            calculator.Points[0].BDCPoint.Should().BeSameAs(bdc[0]);
            calculator.Points[0].Distance.In(DistanceUnit.Meter).Should().BeApproximately(calculatedRange, 1e-2);
            calculator.Points[0].PointLocation.Should().Be(location);
        }

        [Fact]
        public void NoMatch()
        {
            var bdc = new ReticleBulletDropCompensatorPointCollection()
            {
                new ReticleBulletDropCompensatorPoint()
                {
                    Position = new ReticlePosition(0.As(AngularUnit.CmPer100Meters), -10.As(AngularUnit.CmPer100Meters))
                }
            };


            var trajectory = new[]
            {
                new TrajectoryPoint(TimeSpan.FromSeconds(0),
                                    10.As(WeightUnit.Gram),
                                    0.As(DistanceUnit.Meter),
                                    1000.As(VelocityUnit.MetersPerSecond), 1,
                                    0.As(DistanceUnit.Centimeter), 0.As(DistanceUnit.Centimeter)),      //first point is ignored
            
                new TrajectoryPoint(TimeSpan.FromSeconds(1),
                                    10.As(WeightUnit.Gram),
                                    100.As(DistanceUnit.Meter),
                                    1000.As(VelocityUnit.MetersPerSecond), 1,
                                    1.As(DistanceUnit.Centimeter), 0.As(DistanceUnit.Centimeter)),

                new TrajectoryPoint(TimeSpan.FromSeconds(1),
                                    10.As(WeightUnit.Gram),
                                    200.As(DistanceUnit.Meter),
                                    1000.As(VelocityUnit.MetersPerSecond), 1,
                                    2.As(DistanceUnit.Centimeter), 0.As(DistanceUnit.Centimeter))
            };


            var calculator = new TrajectoryToReticleCalculator(trajectory, bdc, 100.As(DistanceUnit.Meter));
            calculator.UpdatePoints(1);

            calculator.Points.Should().HaveCount(0);
        }

        [Fact]
        public void RealDataTest1()
        {
            var reticle = new MilDotReticle();
            var data = new ShotData()
            {
                Ammunition = new AmmunitionLibraryEntry()
                {
                    Ammunition = new Ammunition()
                    {
                        BallisticCoefficient = new BallisticCoefficient(0.365, DragTableId.G1),
                        MuzzleVelocity = 2600.As(VelocityUnit.FeetPerSecond),
                        Weight = 65.As(WeightUnit.Grain)
                    }
                },
                Atmosphere = new Atmosphere(),
                Weapon = new Rifle()
                {
                    Zero = new ZeroingParameters()
                    {
                        Distance = 100.As(DistanceUnit.Yard),
                    },
                    Sight = new Sight()
                    {
                        SightHeight = 2.5.As(DistanceUnit.Inch),
                    }
                },
                Parameters = new ShotParameters()
                {
                    MaximumDistance = 1000.As(DistanceUnit.Yard),
                    Step = 100.As(DistanceUnit.Yard),
                }
            };

            var calculator = new TrajectoryToReticleCalculator(data, reticle.BulletDropCompensator, 100.As(DistanceUnit.Meter));
            calculator.UpdatePoints(1.0);
            calculator.Points.Should().HaveCount(8);
            calculator.Points[0].Distance.In(DistanceUnit.Yard).Should().BeApproximately(13, 0.9);
            calculator.Points[1].Distance.In(DistanceUnit.Yard).Should().BeApproximately(16, 0.9);
            calculator.Points[2].Distance.In(DistanceUnit.Yard).Should().BeApproximately(21, 0.9);
            calculator.Points[3].Distance.In(DistanceUnit.Yard).Should().BeApproximately(31, 0.9);
            calculator.Points[4].Distance.In(DistanceUnit.Yard).Should().BeApproximately(255, 4);
            calculator.Points[5].Distance.In(DistanceUnit.Yard).Should().BeApproximately(355, 4);
            calculator.Points[6].Distance.In(DistanceUnit.Yard).Should().BeApproximately(440, 4);
            calculator.Points[7].Distance.In(DistanceUnit.Yard).Should().BeApproximately(510, 4);

            calculator.Points[0].PointLocation.Should().Be(TrajectoryToReticleCalculator.PointLocation.Near);
            calculator.Points[1].PointLocation.Should().Be(TrajectoryToReticleCalculator.PointLocation.Near);
            calculator.Points[2].PointLocation.Should().Be(TrajectoryToReticleCalculator.PointLocation.Near);
            calculator.Points[3].PointLocation.Should().Be(TrajectoryToReticleCalculator.PointLocation.Near);
            calculator.Points[4].PointLocation.Should().Be(TrajectoryToReticleCalculator.PointLocation.Far);
            calculator.Points[5].PointLocation.Should().Be(TrajectoryToReticleCalculator.PointLocation.Far);
            calculator.Points[6].PointLocation.Should().Be(TrajectoryToReticleCalculator.PointLocation.Far);
            calculator.Points[7].PointLocation.Should().Be(TrajectoryToReticleCalculator.PointLocation.Far);

            calculator.Points[0].BDCPoint.Position.Y.Should().Be(-4.As(AngularUnit.Mil));
            calculator.Points[1].BDCPoint.Position.Y.Should().Be(-3.As(AngularUnit.Mil));
            calculator.Points[2].BDCPoint.Position.Y.Should().Be(-2.As(AngularUnit.Mil));
            calculator.Points[3].BDCPoint.Position.Y.Should().Be(-1.As(AngularUnit.Mil));
            calculator.Points[4].BDCPoint.Position.Y.Should().Be(-1.As(AngularUnit.Mil));
            calculator.Points[5].BDCPoint.Position.Y.Should().Be(-2.As(AngularUnit.Mil));
            calculator.Points[6].BDCPoint.Position.Y.Should().Be(-3.As(AngularUnit.Mil));
            calculator.Points[7].BDCPoint.Position.Y.Should().Be(-4.As(AngularUnit.Mil));
        }
        
    }
}
