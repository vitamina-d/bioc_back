using System.Text.Json.Serialization;

namespace Application.DTO.Python
{

    public class SequenceDto
    {
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
    }
}
