using System.Text.Json.Serialization;

namespace Domain.DTO.Plumber
{
    public class DataAlignDto
    {
        [JsonPropertyName("score")]
        public double Score { get; set; }
        [JsonPropertyName("pattern_align")]
        public string Pattern_Align { get; set; }
        [JsonPropertyName("subject_align")]
        public string Subject_Align { get; set; }
    }
}
