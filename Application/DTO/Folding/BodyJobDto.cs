using System.Text.Json.Serialization;

namespace Application.DTO.Folding
{
    public class BodyJobDto
    {
        [JsonPropertyName("apiKey")]
        public string ApiKey { get; set; } 
        [JsonPropertyName("jobId")]
        public string JobId { get; set; }

    }
}
