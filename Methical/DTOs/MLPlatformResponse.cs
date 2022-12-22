using System.Text.Json.Serialization;

namespace Methical.DTOs
{
    public class MLPlatformResponse
    {
        [JsonPropertyName("data")]
        public object[] Data { get; set; }
        [JsonPropertyName("is_generating")]
        public bool IsGenerating { get; set; }
        [JsonPropertyName("duration")]
        public float Duration { get; set; }
        [JsonPropertyName("average_duration")]
        public float AverageDuration { get; set; }
    }
}
