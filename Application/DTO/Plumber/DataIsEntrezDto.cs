using System.Text.Json.Serialization;

namespace Application.DTO.Plumber
{
    public class DataIsEntrezDto
    {
        [JsonPropertyName("is_entrez")]
        public bool IsEntrez { get; set; }
    }
}
/*             
    {
        "status": "success",
        "time_secs": 0.1343,
        "data": {
        "is_entrez": false
        }
    }
*/