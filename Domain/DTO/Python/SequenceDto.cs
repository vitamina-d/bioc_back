using System.Text.Json.Serialization;

namespace Domain.DTO.Python
{

    public class SequenceDto
    {
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
    }
}
