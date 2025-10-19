using System.Text.Json.Serialization;

namespace Application.DTO.Folding
{
    public class ResponseStatusDto
    {
        [JsonPropertyName("jobId")]
        public string JobId { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
