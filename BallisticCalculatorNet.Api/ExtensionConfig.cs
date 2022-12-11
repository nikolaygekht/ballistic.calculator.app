using System.Text.Json.Serialization;

namespace BallisticCalculatorNet.Api
{
    /// <summary>
    /// Extension configuration template
    /// </summary>
    public class ExtensionConfig
    {
        public class Command
        {
            [JsonPropertyName("id")]
            public string ID { get; set; }

            [JsonPropertyName("displayName")]
            public string DisplayName { get; set; }
        }

        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("executableName")]
        public string ExecutableName { get; set; }

        [JsonPropertyName("commands")]
        public Command[] Commands { get; set; }
    }
}
