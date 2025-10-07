using System.Text.Json.Serialization;

namespace Application.DTO.Python
{
    public class BodyReverseComplementDto
    {
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
        [JsonPropertyName("reverse")]
        public bool Reverse { get; set; }
        [JsonPropertyName("complement")]
        public bool Complement { get; set; }
    }
}
//python