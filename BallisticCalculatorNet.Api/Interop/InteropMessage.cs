using System.Text.Json.Serialization;

namespace BallisticCalculatorNet.Api.Interop
{
    public class InteropMessage
    {
        [JsonPropertyName("command")]
        public string Command { get; set; }
        
        [JsonPropertyName("argument")]
        public string Argument { get; set; }

        [JsonPropertyName("data1")]
        public string Data1 { get; set; }

        [JsonPropertyName("data2")]
        public string Data2 { get; set; }
    }
}
