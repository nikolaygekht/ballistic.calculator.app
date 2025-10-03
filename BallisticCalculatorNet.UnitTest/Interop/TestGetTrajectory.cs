using BallisticCalculator;
using BallisticCalculatorNet.Types;
using BallisticCalculatorNet.Api.Interop;
using BallisticCalculatorNet.UnitTest.Tools;
using FluentAssertions;
using Gehtsoft.Measurements;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.Interop
{
    public class TestGetTrajectory
    {
        [Fact]
        public void Connection()
        {
            var host = new Mock<IInteropServerHost>();

            using var server = new InteropServer(host.Object, 31559);
            server.Start();
            WaitFor(100, () => server.Started).Should().BeTrue();

            bool connected = false;

            using var client = new InteropClient("127.0.0.1", 31559);
            client.CalculatorConnected += (_, _) => connected = true;
            client.Connect();
            WaitFor(100, () => connected).Should().BeTrue();
            client.Connected.Should().BeTrue();
        }

        [Fact]
        public void ReturnEmpty()
        {
            var host = new Mock<IInteropServerHost>();
            host.Setup(h => h.MdiActiveWindow)
                .Returns((object)null);

            using var server = new InteropServer(host.Object, 31559);
            server.Start();
            WaitFor(100, () => server.Started).Should().BeTrue();

            using var client = new InteropClient("127.0.0.1", 31559);
            client.Connect();
            WaitFor(100, () => client.Connected).Should().BeTrue();

            bool responseReceived = false;
            InteropGetTrajectoryResponse response = null;
            client.TrajectoryReceived += (_, args) => { responseReceived = true; response = args.Response; };
            client.RequestTrajectory();
            WaitFor(100, () => responseReceived).Should().BeTrue();
            response.Should().BeNull();
        }

        [Fact]
        public void ReturnValue()
        {
            var loader = TableLoader.FromResource("g1_nowind");
            var shotData = new ShotData()
            {
                Ammunition = new AmmunitionLibraryEntry()
                {
                    Name = "Table",
                    Ammunition = loader.Ammunition,
                },
                Atmosphere = loader.Atmosphere,
                Parameters = loader.ShotParameters,
                Weapon = loader.Rifle,
                Wind = [loader.Wind]
            };
            
            var window = new Mock<IShotForm>();
            window.Setup(w => w.ShotData)
                .Returns(shotData);
            window.Setup(w => w.Trajectory)
                .Returns([.. loader.Trajectory]);
            window.Setup(w => w.MeasurementSystem)
                .Returns(MeasurementSystem.Metric);
            window.Setup(w => w.AngularUnits)
                .Returns(AngularUnit.MOA);
            
            var host = new Mock<IInteropServerHost>();
            host.Setup(h => h.MdiActiveWindow)
                .Returns((object)window.Object);

            using var server = new InteropServer(host.Object, 31559);
            server.Start();
            WaitFor(100, () => server.Started).Should().BeTrue();

            using var client = new InteropClient("127.0.0.1", 31559);
            client.Connect();
            WaitFor(100, () => client.Connected).Should().BeTrue();

            bool responseReceived = false;
            InteropGetTrajectoryResponse response = null;
            client.TrajectoryReceived += (_, args) => { responseReceived = true; response = args.Response; };
            client.RequestTrajectory();
            WaitFor(250, () => responseReceived).Should().BeTrue();
            response.Should().NotBeNull();

            //TBD: check the response
        }

        private static bool WaitFor(int timeout, Func<bool> predicate)
        {
            var end = DateTime.Now.AddMilliseconds(timeout);
            while (!predicate() && DateTime.Now < end)
                Thread.Sleep(1);
            return predicate();
        }
    }
}
