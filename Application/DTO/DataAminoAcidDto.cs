using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class DataAminoAcidDto
    {
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
    }
}
