using BallisticCalculator.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WatsonTcp;

namespace BallisticCalculatorNet.Api.Interop
{
    public sealed class InteropServer : IDisposable
    {
        private readonly WatsonTcpServer mServer;
        private readonly IInteropServerHost mHost;

        public bool Started => mServer.IsListening;

        public InteropServer(IInteropServerHost host, int serverPort)
        {
            mHost = host;
            mServer = new WatsonTcpServer("0.0.0.0", serverPort);
            mServer.Events.MessageReceived += MessageReceived;
        }

        public void Start() => mServer.Start();
        public void Stop() => mServer.Stop();

        public void Dispose()
        {
            if (mServer.IsListening)
                mServer.Stop();
            try
            {
                mServer.Dispose();
            }
            catch (AggregateException e)
            {
                if (e.InnerExceptions.All(x => x is TaskCanceledException))
                    return;
                throw;
            }
        }

        private void MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            var message = JsonSerializer.Deserialize<InteropMessage>(Encoding.UTF8.GetString(args.Data));
            if (message != null)
            {
                switch (message.Command)
                {
                    case "GetTrajectory":
                        ProcessMessageGetTrajectory(args.Client.Guid);
                        break;
                }
            }
        }

        private void ProcessMessageGetTrajectory(Guid client)
        {
            InteropMessage message;


            if (mHost.MdiActiveWindow is not IShotForm mdiWindow)
            {
                message = new InteropMessage
                {
                    Command = "GetTrajectory",
                    Argument = "NONE",
                };
                mServer.SendAsync(client, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message))).ConfigureAwait(false).GetAwaiter().GetResult();
                return;
            }

            var response = new InteropGetTrajectoryResponse()
            {
                ShotData = mdiWindow.ShotData,
                Trajectory = mdiWindow.Trajectory,
                AngularUnits = mdiWindow.AngularUnits,
                MeasurementSystem = mdiWindow.MeasurementSystem,
            };

            var serializer = new BallisticXmlSerializer();

            message = new InteropMessage
            {
                Command = "GetTrajectory",
                Argument = "OK",
                Data1 = serializer.Serialize(response).OuterXml,
            };

            mServer.SendAsync(client, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message))).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
