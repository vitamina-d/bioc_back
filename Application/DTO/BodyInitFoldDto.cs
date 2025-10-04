using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class BodyInitFoldDto
    {
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
        [JsonPropertyName("frame")]
        public string Frame { get; set; }
    }
}
