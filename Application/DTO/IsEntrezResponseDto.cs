using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class IsEntrezResponseDto
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("time_secs")]
        public double Time_Secs { get; set; }
        [JsonPropertyName("data")]
        public IsEntrezDataDto Data { get; set; }

    }
    public class IsEntrezDataDto
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