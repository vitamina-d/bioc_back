using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class SeqByRangeResponseDto
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
 "time_secs": 0.0048,
 "data": {
   "sequence_length": 24676,
   "sequence": "AA"
       }
 }
        */