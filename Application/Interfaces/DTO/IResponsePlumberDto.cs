using System.Text.Json.Serialization;

namespace Application.Interfaces.DTO
{
    public interface IResponsePlumberDto
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
