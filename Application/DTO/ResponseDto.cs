using Application.Interfaces.DTO;
using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class ResponseDto<T> : IResponsePlumberDto
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("datetime")]
        public string DateTime { get; set; }
        [JsonPropertyName("time_secs")]
        public double Time { get; set; }
        [JsonPropertyName("data")]
        public T? Data { get; set; }
    }
}
