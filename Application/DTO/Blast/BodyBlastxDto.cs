using System.Text.Json.Serialization;

namespace Application.DTO.Blast
{
    public class BodyBlastxDto
    {
        [JsonPropertyName("sequence")]
        public required string Sequence { get; set; }
    }
}
