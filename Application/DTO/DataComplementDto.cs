using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class DataComplementDto
    {
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
    }
}

/*
    {
      "status": "success",
      "time_secs": 0.3463,
        data = list(
            message = "Ok",
            sequence = as.character(sequence) # AAString a texto
        )
    }
                 */
