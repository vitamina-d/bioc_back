using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class BodyBlastxDto
    {
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
    }
}
