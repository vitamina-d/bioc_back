using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class SeqBySymbolResponseDto
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("time_secs")]
        public double Time_Secs { get; set; }
        [JsonPropertyName("data")]
        public SequenceDataDto Data { get; set; }

    }
}
/*
    {
      "status": "success",
      "time_secs": 2.2354,
      "data": {
        "complete": true,
        "sequence_length": 24676,
        "sequence": "AT"
      }
    }
*/