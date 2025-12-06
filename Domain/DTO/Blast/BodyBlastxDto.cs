using System.Text.Json.Serialization;

namespace Domain.DTO.Blast
{
    public class BodyBlastxDto
    {
        [JsonPropertyName("sequence")]
        public required string Sequence { get; set; }
    }
}
