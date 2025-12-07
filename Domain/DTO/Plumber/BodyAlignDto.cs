using System.Text.Json.Serialization;

namespace Domain.DTO.Plumber
{
    public class BodyAlignDto
    {
        [JsonPropertyName("pattern")]
        public string Pattern { get; set; }
        [JsonPropertyName("subject")]
        public string Subject { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; } 
        [JsonPropertyName("gapOpening")]
        public int GapOpening { get; set; }
        [JsonPropertyName("gapExtension")]
        public int GapExtension { get; set; }
    }
}
