using System.Text.Json.Serialization;

namespace Domain.DTO.Plumber
{
    public class DataDetailDto
    {
        [JsonPropertyName("entrez")]
        public string Entrez { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("genename")]
        public string Genename { get; set; }
        [JsonPropertyName("genetype")]
        public string Genetype { get; set; }
        [JsonPropertyName("alias")]
        public string[]? Alias { get; set; }
    }
}
