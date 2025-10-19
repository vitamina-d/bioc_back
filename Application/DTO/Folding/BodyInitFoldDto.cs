using System.Text.Json.Serialization;

namespace Application.DTO.Folding
{
    public class BodyInitFoldDto
    {
        [JsonPropertyName("aminoacid")]
        public string Aminoacid { get; set; } //aminoacidSequence
    }
}
