using System.Text.Json.Serialization;

namespace Domain.DTO.Folding
{
    public class BodyFoldDto
    {
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
        [JsonPropertyName("frame")]
        public string Frame { get; set; }
        [JsonPropertyName("pdbid")]
        public string PbdId { get; set; }
    }
}
