using System.Text.Json.Serialization;

namespace Methical.DTOs
{
    public class MLPlatformSpaceRequest
    {
        [JsonPropertyName("data")]
        public string[] Data { get; set; }
    }
}
