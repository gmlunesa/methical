using System.Text.Json.Serialization;

namespace Methical.DTOs
{
    public class MLPlatformRequest
    {
        [JsonPropertyName("data")]
        public string[] Data { get; set; }
    }
}
