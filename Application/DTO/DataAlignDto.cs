using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class DataAlignDto
    {
        [JsonPropertyName("score")]
        public double Score { get; set; }
        [JsonPropertyName("pattern_align")]
        public string Pattern_Align { get; set; }
        [JsonPropertyName("subject_align")]
        public string Subject_Align { get; set; }
    }
}

/*
    {
      "status": "success",
      "time_secs": 0.3463,
      "data": {
        "score": -1.9358,
        "type": "global",
        "pattern": "ACT",
        "subject": "ACC",
        "pattern_align": "ACT",
        "subject_align": "ACC"
      }
    }
                 */
