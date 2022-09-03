using BallisticCalculator;
using BallisticCalculatorNet.InputPanels;
using FluentAssertions;
using Gehtsoft.Winforms.FluentAssertions;
using Gehtsoft.Measurements;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Windows.Forms;
using System.Globalization;

namespace BallisticCalculatorNet.UnitTest.OutputPanels
{
    public class TrajectoryTest
    {
        [Fact]
        public void ContainListview()
        {
            var ctrl = new TrajectoryControl();
            var list = ctrl.ListView("listView");
            list.Columns.Count.Should().Be(13);
            list.Should().NotBeNull();
            list.VirtualMode.Should().BeTrue();
            list.VirtualListSize.Should().Be(0);
        }


        [Theory]
        [InlineData(0, "Hidden", 0, false)]
        [InlineData(1, "Range", 1, true)]
        [InlineData(2, "Velocity", 1, true)]
        [InlineData(3, "Mach", 1, true)]
        [InlineData(4, "Path", 1, true)]
        [InlineData(5, "Hold", 1, true)]
        [InlineData(6, "Clicks", 1, true)]
        [InlineData(7, "Windage", 1, true)]
        [InlineData(8, "Wnd. Adj.", 1, true)]
        [InlineData(9, "Clicks", 1, true)]
        [InlineData(10, "Flight Time", 1, false)]
        [InlineData(11, "Energy", 1, true)]
        [InlineData(12, "O.G.W.", 1, true)]
        public void ColumnsDefined(int index, string name, int size, bool right)
        {
            var ctrl = new TrajectoryControl();
            var list = ctrl.ListView("listView");
            list.Columns.Count.Should().BeGreaterThan(index);
            var column = list.Columns[index];

            column.Text.Should().Be(name);
            if (size == 0)
                column.Width.Should().Be(0);
            else
                column.Width.Should().BeGreaterThan(50);

            if (index >0 && right)
                column.TextAlign.Should().Be(System.Windows.Forms.HorizontalAlignment.Right);
            else
                column.TextAlign.Should().Be(System.Windows.Forms.HorizontalAlignment.Left);
        }

        [Fact]
        public void SizeDefinedByTrajectory()
        {
            var ctrl = new TrajectoryControl();
            var list = ctrl.ListView("listView");
            TrajectoryPoint[] trajectory = new TrajectoryPoint[5];
            ctrl.Trajectory = trajectory;
            list.VirtualListSize.Should().Be(5);
        }

        [Fact]
        public void ClearAction()
        {
            var ctrl = new TrajectoryControl();
            var list = ctrl.ListView("listView");
            TrajectoryPoint[] trajectory = new TrajectoryPoint[5];
            ctrl.Trajectory = trajectory;
            ctrl.Clear();
            list.VirtualListSize.Should().Be(0);
            list.Columns.Count.Should().Be(13);
        }

        [Fact]
        public void SaveColumnSize()
        {
            var config = (new ConfigurationBuilder())
                .AddCommandLine(Array.Empty<string>()).Build();

            ControlConfiguration.Configuration = config;
            var ctrl = new TrajectoryControl();
            var list = ctrl.ListView("listView");

            list.Columns[1].Width = 10;
            list.Columns[2].Width = 20;
            list.Columns[3].Width = 30;
            list.Columns[4].Width = 40;
            list.Columns[5].Width = 50;
            list.Columns[6].Width = 60;
            list.Columns[7].Width = 70;
            list.Columns[8].Width = 80;
            list.Columns[9].Width = 90;
            list.Columns[10].Width = 100;
            list.Columns[11].Width = 110;
            list.Columns[12].Width = 120;

            ctrl.OnClose();

            config["state:trajectory:column:1"].Should().Be("10");
            config["state:trajectory:column:2"].Should().Be("20");
            config["state:trajectory:column:3"].Should().Be("30");
            config["state:trajectory:column:4"].Should().Be("40");
            config["state:trajectory:column:5"].Should().Be("50");
            config["state:trajectory:column:6"].Should().Be("60");
            config["state:trajectory:column:7"].Should().Be("70");
            config["state:trajectory:column:8"].Should().Be("80");
            config["state:trajectory:column:9"].Should().Be("90");
            config["state:trajectory:column:10"].Should().Be("100");
            config["state:trajectory:column:11"].Should().Be("110");
            config["state:trajectory:column:12"].Should().Be("120");
        }

        [Fact]
        public void RestoreColumnSize()
        {
            var config = (new ConfigurationBuilder())
                .AddCommandLine(new[]
                {
                    "state:trajectory:column:0=0",
                    "state:trajectory:column:1=10",
                    "state:trajectory:column:2=20",
                    "state:trajectory:column:3=30",
                    "state:trajectory:column:4=40",
                    "state:trajectory:column:5=50",
                    "state:trajectory:column:6=60",
                    "state:trajectory:column:7=70",
                    "state:trajectory:column:8=80",
                    "state:trajectory:column:9=90",
                    "state:trajectory:column:10=100",
                    "state:trajectory:column:11=110",
                    "state:trajectory:column:12=120",
                }).Build();

            ControlConfiguration.Configuration = config;
            var ctrl = new TrajectoryControl();
            var list = ctrl.ListView("listView");
            
            list.Columns[0].Width.Should().Be(0);
            list.Columns[1].Width.Should().Be(10);
            list.Columns[2].Width.Should().Be(20);
            list.Columns[3].Width.Should().Be(30);
            list.Columns[4].Width.Should().Be(40);
            list.Columns[5].Width.Should().Be(50);
            list.Columns[6].Width.Should().Be(60);
            list.Columns[7].Width.Should().Be(70);
            list.Columns[8].Width.Should().Be(80);
            list.Columns[9].Width.Should().Be(90);
            list.Columns[10].Width.Should().Be(100);
            list.Columns[11].Width.Should().Be(110);
            list.Columns[12].Width.Should().Be(120);
        }

        [Theory]
        [InlineData(MeasurementSystem.Metric, 0, 0, "")]

        [InlineData(MeasurementSystem.Metric, 0, 1, "100m")]
        [InlineData(MeasurementSystem.Imperial, 1, 1, "100yd")]
        [InlineData(MeasurementSystem.Metric, 1, 1, "91m")]

        [InlineData(MeasurementSystem.Metric, 0, 2, "950m/s")]
        [InlineData(MeasurementSystem.Imperial, 1, 2, "2,790ft/s")]
        [InlineData(MeasurementSystem.Metric, 1, 2, "850m/s")]

        [InlineData(MeasurementSystem.Metric, 0, 3, "1.50")]
        [InlineData(MeasurementSystem.Metric, 1, 3, "1.25")]
        [InlineData(MeasurementSystem.Metric, 2, 3, "0.95")]

        [InlineData(MeasurementSystem.Metric, 0, 4, "-2.50cm")]
        [InlineData(MeasurementSystem.Imperial, 1, 4, "-1.50in")]
        [InlineData(MeasurementSystem.Metric, 1, 4, "-3.81cm")]
        [InlineData(MeasurementSystem.Metric, 2, 4, "3.15cm")]

        [InlineData(MeasurementSystem.Metric, 0, 7, "0.00cm")]
        [InlineData(MeasurementSystem.Imperial, 1, 7, "1.18in")]
        [InlineData(MeasurementSystem.Metric, 1, 7, "3.00cm")]
        [InlineData(MeasurementSystem.Metric, 2, 7, "-3.15cm")]


        [InlineData(MeasurementSystem.Metric, 0, 10, "00:00.000")]
        [InlineData(MeasurementSystem.Metric, 1, 10, "00:00.254")]
        [InlineData(MeasurementSystem.Metric, 2, 10, "00:02.456")]

        [InlineData(MeasurementSystem.Metric, 0, 11, "1,000J")]
        [InlineData(MeasurementSystem.Imperial, 1, 11, "970ft·lb")]
        [InlineData(MeasurementSystem.Metric, 1, 11, "1,315J")]

        [InlineData(MeasurementSystem.Metric, 0, 12, "50.0kg")]
        [InlineData(MeasurementSystem.Imperial, 1, 12, "40.0lb")]
        [InlineData(MeasurementSystem.Metric, 1, 12, "18.1kg")]

        public void ItemFormatting(MeasurementSystem ms, int line, int column, string expected)
        {
            var ctrl = new TrajectoryControl
            {
                Culture = CultureInfo.InvariantCulture,
                MeasurementSystem = ms,
                Trajectory = new TrajectoryPoint[]
                {
                    new TrajectoryPoint(TimeSpan.FromMilliseconds(0), 100.As(DistanceUnit.Meter), 950.As(VelocityUnit.MetersPerSecond), 1.5, -2.5.As(DistanceUnit.Centimeter), 0.As(DistanceUnit.Centimeter), 1000.As(EnergyUnit.Joule), 50.As(WeightUnit.Kilogram)),
                    new TrajectoryPoint(TimeSpan.FromMilliseconds(254), 100.As(DistanceUnit.Yard), 2790.As(VelocityUnit.FeetPerSecond), 1.245, -1.5.As(DistanceUnit.Inch), 3.As(DistanceUnit.Centimeter), 970.As(EnergyUnit.FootPound), 40.As(WeightUnit.Pound)),
                    new TrajectoryPoint(TimeSpan.FromMilliseconds(2456), 100.As(DistanceUnit.Yard), 2790.As(VelocityUnit.FeetPerSecond), 0.95, 3.149.As(DistanceUnit.Centimeter), -3.149.As(DistanceUnit.Centimeter), 970.As(EnergyUnit.FootPound), 40.As(WeightUnit.Pound))
                }
            };

            var args = new RetrieveVirtualItemEventArgs(line);
            ctrl.InvokeEventHandler("listView_RetrieveVirtualItem", args);

            args.Item.Should().NotBeNull();
            args.Item.SubItems.Count.Should().BeGreaterThan(column);
            args.Item.SubItems[column].Text.Should().Be(expected);
        }

        [Fact]
        public void DropAndWindgage_NA_Distance()
        {
            var ctrl = new TrajectoryControl
            {
                Culture = CultureInfo.InvariantCulture,
                Sight = new Sight(2.5.As(DistanceUnit.Inch), 1.As(AngularUnit.Mil), 1.As(AngularUnit.Mil)),
                Trajectory = new TrajectoryPoint[]
                {
                    new TrajectoryPoint(TimeSpan.FromMilliseconds(0), 0.As(DistanceUnit.Meter), 950.As(VelocityUnit.MetersPerSecond), 1.5, -2.5.As(DistanceUnit.Centimeter), 0.As(DistanceUnit.Centimeter), 1000.As(EnergyUnit.Joule), 50.As(WeightUnit.Kilogram)),
                }
            };

            var args = new RetrieveVirtualItemEventArgs(0);
            ctrl.InvokeEventHandler("listView_RetrieveVirtualItem", args);
            args.Item.SubItems[5].Text.Should().Be("n/a");
            args.Item.SubItems[6].Text.Should().Be("n/a");
            args.Item.SubItems[8].Text.Should().Be("n/a");
            args.Item.SubItems[9].Text.Should().Be("n/a");
        }

        [Fact]
        public void DropAndWindgage_NA_NoSight()
        {
            var ctrl = new TrajectoryControl
            {
                Culture = CultureInfo.InvariantCulture,
                Sight = null,
                Trajectory = new TrajectoryPoint[]
                {
                    new TrajectoryPoint(TimeSpan.FromMilliseconds(0), 100.As(DistanceUnit.Meter), 950.As(VelocityUnit.MetersPerSecond), 1.5, -2.5.As(DistanceUnit.Centimeter), 0.As(DistanceUnit.Centimeter), 1000.As(EnergyUnit.Joule), 50.As(WeightUnit.Kilogram)),
                }
            };

            var args = new RetrieveVirtualItemEventArgs(0);
            ctrl.InvokeEventHandler("listView_RetrieveVirtualItem", args);
            args.Item.SubItems[6].Text.Should().Be("n/a");
            args.Item.SubItems[9].Text.Should().Be("n/a");
        }

        [Fact]
        public void DropAndWindgage_NA_Sight_NoClickInfo()
        {
            var ctrl = new TrajectoryControl
            {
                Culture = CultureInfo.InvariantCulture,
                Sight = new Sight(),
                Trajectory = new TrajectoryPoint[]
                {
                    new TrajectoryPoint(TimeSpan.FromMilliseconds(0), 100.As(DistanceUnit.Meter), 950.As(VelocityUnit.MetersPerSecond), 1.5, -2.5.As(DistanceUnit.Centimeter), 0.As(DistanceUnit.Centimeter), 1000.As(EnergyUnit.Joule), 50.As(WeightUnit.Kilogram)),
                }
            };

            var args = new RetrieveVirtualItemEventArgs(0);
            ctrl.InvokeEventHandler("listView_RetrieveVirtualItem", args);
            args.Item.SubItems[6].Text.Should().Be("n/a");
            args.Item.SubItems[9].Text.Should().Be("n/a");
        }

        [Theory]
        [InlineData(100, 0, AngularUnit.Mil, 0.5, "0.00mil", "0")]
        [InlineData(100, 15, AngularUnit.Mil, 0.5, "1.53mil", "3")]
        [InlineData(100, 15, AngularUnit.MOA, 0.5, "5.16moa", "10")]
        public void Drop(int distance, double drop, AngularUnit angularUnits, double scopeStep, string expectedDrop, string expectedClicks)
        {
            var ctrl = new TrajectoryControl
            {
                Culture = CultureInfo.InvariantCulture,
                AngularUnits = angularUnits,
                Sight = new Sight(0.As(DistanceUnit.Centimeter), scopeStep.As(angularUnits), scopeStep.As(angularUnits)),
                Trajectory = new TrajectoryPoint[]
                {
                    new TrajectoryPoint(TimeSpan.FromSeconds(0.1), 
                                        10.As(WeightUnit.Gram), 
                                        distance.As(DistanceUnit.Meter), 
                                        1000.As(VelocityUnit.MetersPerSecond), 1, 
                                        drop.As(DistanceUnit.Centimeter), 0.As(DistanceUnit.Centimeter))
                }
            };

            var args = new RetrieveVirtualItemEventArgs(0);
            ctrl.InvokeEventHandler("listView_RetrieveVirtualItem", args);

            args.Item.SubItems[5].Text.Should().Be(expectedDrop);
            args.Item.SubItems[6].Text.Should().Be(expectedClicks);
        }

        [Theory]
        [InlineData(100, 0, AngularUnit.Mil, 0.5, "0.00mil", "0")]
        [InlineData(100, 15, AngularUnit.Mil, 0.5, "1.53mil", "3")]
        [InlineData(100, 15, AngularUnit.MOA, 0.5, "5.16moa", "10")]
        public void Windage(int distance, double windage, AngularUnit angularUnits, double scopeStep, string expectedWindage, string expectedClicks)
        {
            var ctrl = new TrajectoryControl
            {
                Culture = CultureInfo.InvariantCulture,
                AngularUnits = angularUnits,
                Sight = new Sight(0.As(DistanceUnit.Centimeter), scopeStep.As(angularUnits), scopeStep.As(angularUnits)),
                Trajectory = new TrajectoryPoint[]
                {
                    new TrajectoryPoint(TimeSpan.FromSeconds(0.1),
                                        10.As(WeightUnit.Gram),
                                        distance.As(DistanceUnit.Meter),
                                        1000.As(VelocityUnit.MetersPerSecond), 1,
                                        0.As(DistanceUnit.Centimeter), windage.As(DistanceUnit.Centimeter))
                }
            };

            var args = new RetrieveVirtualItemEventArgs(0);
            ctrl.InvokeEventHandler("listView_RetrieveVirtualItem", args);

            args.Item.SubItems[8].Text.Should().Be(expectedWindage);
            args.Item.SubItems[9].Text.Should().Be(expectedClicks);
        }
    }
}
