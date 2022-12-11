using BallisticCalculator.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
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
            mServer.Dispose();
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
            
            var mdiWindow = mHost.MdiActiveWindow as IShotForm;
            
            if (mdiWindow == null)
            {
                message = new InteropMessage
                {
                    Command = "GetTrajectory",
                    Argument = "NONE",
                };
                mServer.Send(client, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message)));
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

            mServer.Send(client, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message)));
        }
    }
}
