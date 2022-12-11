using BallisticCalculator.Serialization;
using System;
using System.Text;
using System.Text.Json;
using System.Xml;
using WatsonTcp;

namespace BallisticCalculatorNet.Api.Interop
{
    public sealed class InteropClient : IDisposable
    {
        private readonly WatsonTcpClient mClient;

        public event EventHandler<EventArgs> CalculatorConnected;
        public event EventHandler<EventArgs> InvalidResponseReceived;
        public event EventHandler<InteropGetTrajectoryEventArgs> TrajectoryReceived;

        public bool Connected => mClient.Connected;

        public InteropClient(string serverAddress, int serverPort)
        {
            mClient = new WatsonTcpClient(serverAddress, serverPort);
            mClient.Events.MessageReceived += MessageReceived;
            mClient.Events.ServerConnected += ServerConnected;
        }

        public void Connect() => mClient.Connect();
        
        public void Disconnect() => mClient.Disconnect();

        public void RequestTrajectory()
        {
            var message = new InteropMessage()
            {
                Command = "GetTrajectory"
            };
            var json = JsonSerializer.Serialize(message);
            mClient.Send(Encoding.UTF8.GetBytes(json));
        }

        private void ServerConnected(object sender, ConnectionEventArgs args)
        {
            CalculatorConnected?.Invoke(this, EventArgs.Empty);
        }

        private void MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            var response = JsonSerializer.Deserialize<InteropMessage>(Encoding.UTF8.GetString(args.Data));
            if (response == null)
            {
                InvalidResponseReceived?.Invoke(this, EventArgs.Empty);
                return;
            }
            switch (response.Command)
            {
                case "GetTrajectory":
                    ProcessTrajectoryReceived(response);
                    break;
                default:
                    InvalidResponseReceived?.Invoke(this, EventArgs.Empty);
                    break;
            }
        }

        private void ProcessTrajectoryReceived(InteropMessage response)
        {
            if (response.Argument != "OK")
                TrajectoryReceived?.Invoke(this, new InteropGetTrajectoryEventArgs() { Response = null });
            var deserializer = new BallisticXmlDeserializer();
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(response.Data1);
                var trajectory = deserializer.Deserialize<InteropGetTrajectoryResponse>(doc.DocumentElement);
                TrajectoryReceived?.Invoke(this, new InteropGetTrajectoryEventArgs() { Response = trajectory });
            }
            catch (Exception )
            {
                InvalidResponseReceived?.Invoke(this, EventArgs.Empty);
            }

        }

        public void Dispose()
        {
            if (mClient.Connected)
                mClient.Disconnect();
            mClient.Dispose();
        }
    }
}
