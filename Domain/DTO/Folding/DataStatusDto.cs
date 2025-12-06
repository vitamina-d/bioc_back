using System.Text.Json.Serialization;

namespace Domain.DTO.Folding
{
    public class DataStatusDto
    {
        [JsonPropertyName("jobId")]
        public string JobId { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
