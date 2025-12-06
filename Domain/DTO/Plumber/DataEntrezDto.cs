using System.Text.Json.Serialization;

namespace Domain.DTO.Plumber
{
    public class DataEntrezDto
    {
        [JsonPropertyName("entrez")]
        public string Entrez { get; set; }
    }
}
