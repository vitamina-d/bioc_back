using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class DataFoldDto
    {
        [JsonPropertyName("entrez")]
        public string Entrez { get; set; }
    }
}
