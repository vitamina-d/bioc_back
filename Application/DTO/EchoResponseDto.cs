using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class EchoResponseDto
    {
        [JsonPropertyName("msg")]
        public string Msg { get; set; }
    }
}

/*
    {
      "msg": "The message is: 'msg'"
    }
*/
