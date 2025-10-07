using System.Text.Json.Serialization;

namespace Application.DTO.Plumber
{
    public class DataPercentDto
    {
        [JsonPropertyName("composition")]
        public CompositionDto? Composition { get; set; }
        [JsonPropertyName("cpg_islands")]
        public CpgIslandsDto? CpgIslands { get; set; }

    }
    public class CompositionDto
    {
        [JsonPropertyName("length")]
        public int Length { get; set; }
        [JsonPropertyName("nucleotides")]
        public Nucleotides Nucleotides { get; set; }
    }
    public class Nucleotides
    {
        [JsonPropertyName("A")]
        public int A { get; set; }
        [JsonPropertyName("C")]
        public int C { get; set; }
        [JsonPropertyName("G")]
        public int G { get; set; }
        [JsonPropertyName("T")]
        public int T { get; set; }
        [JsonPropertyName("other")]
        public int Other { get; set; }
    }
    public class CpgIslandsDto
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("start")]
        public int[] Start { get; set; }
    }
}
    /*

{
  "code": 200,
  "datetime": "2025-08-28 15:18:00",
  "time_secs": 0.1,
  "data": {
    "message": "Ok.",
    "composition": {
      "length": 4,
      "nucleotides": {
        "A": 1,
        "C": 1,
        "G": 1,
        "T": 1,
        "other": 0
      }
    },
    "cpg_islands": {
      "count": 1,
      "start": [
        2
      ]
    }
  }
}
    }*/
