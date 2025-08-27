using System.Text.Json.Serialization;

namespace Application.Interfaces.DTO
{
    public interface IResponsePlumberDto
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("datetime")]
        public string DateTime { get; set; }
        [JsonPropertyName("time_secs")]
        public double Time { get; set; }
    }
}
