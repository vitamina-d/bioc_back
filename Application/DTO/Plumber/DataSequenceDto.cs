using System.Text.Json.Serialization;

namespace Application.DTO.Plumber
{

    public class DataSequenceDto
    {
        [JsonPropertyName("index")]
        public int Index { get; set; } 
        [JsonPropertyName("start")]
        public int Start { get; set; } //complete / exons
        [JsonPropertyName("end")]
        public int End { get; set; }
        [JsonPropertyName("sequence_length")]
        public int Lenght { get; set; }
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
    }
}
