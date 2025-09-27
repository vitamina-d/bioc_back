using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class DataEntrezDto
    {
        [JsonPropertyName("entrez")]
        public string Entrez { get; set; }
    }
}
