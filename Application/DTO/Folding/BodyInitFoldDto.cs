using System.Text.Json.Serialization;

namespace Application.DTO.Folding
{
    public class BodyInitFoldDto
    {
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
        [JsonPropertyName("frame")]
        public int Frame { get; set; }
    }
}
