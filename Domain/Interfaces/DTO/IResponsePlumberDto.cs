using System.Text.Json.Serialization;

namespace Domain.Interfaces.DTO
{
    public interface IResponsePlumberDto
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
