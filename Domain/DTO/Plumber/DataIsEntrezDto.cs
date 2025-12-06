using System.Text.Json.Serialization;

namespace Domain.DTO.Plumber
{
    public class DataIsEntrezDto
    {
        [JsonPropertyName("is_entrez")]
        public bool IsEntrez { get; set; }
    }
}
