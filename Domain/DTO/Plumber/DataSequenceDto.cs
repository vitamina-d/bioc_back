using System.Text.Json.Serialization;

namespace Domain.DTO.Plumber
{
    public class DataSequenceDto
    {
        [JsonPropertyName("index")]
        public int Index { get; set; } 
        [JsonPropertyName("start")]
        public int Start { get; set; } 
        [JsonPropertyName("end")]
        public int End { get; set; }
        [JsonPropertyName("sequence_length")]
        public int Lenght { get; set; }
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
    }
}
