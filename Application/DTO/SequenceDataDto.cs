using System.Numerics;
using System.Text.Json.Serialization;

namespace Application.DTO
{

    public class SequenceDataDto
    {
        [JsonPropertyName("complete")]
        public bool Complete { get; set; } //complete / exons
        [JsonPropertyName("sequence_length")]
        public int SequenceLength { get; set; }
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
    }
}
