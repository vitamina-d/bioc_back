using System.Text.Json.Serialization;

namespace Domain.DTO.Folding
{
    public class BodyInitFoldDto
    {
        [JsonPropertyName("apiKey")]
        public string ApiKey { get; set; } //
        [JsonPropertyName("aminoacid")]
        public string Aminoacid { get; set; } //aminoacidSequence
    }
}
