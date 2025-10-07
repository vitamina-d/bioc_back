using System.Text.Json.Serialization;

namespace Application.DTO.Python
{
    public class BodyTranslateDto
    {
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
        [JsonPropertyName("frame")]
        public int Frame { get; set; }

    }
}
