using System.Text.Json.Serialization;

namespace Application.DTO.Plumber
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
  "time_secs": 3.2282,
  "data": {
    "score": -4.0365,
    "gapOpening": -2,
    "gapExtension": -1,
    "type": "global",
    "pattern_align": "A--C",
    "subject_align": "AGGC"
  }
}
                 */
