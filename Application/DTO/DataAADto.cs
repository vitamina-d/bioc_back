using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class DataAADto
    {
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
    }
}
