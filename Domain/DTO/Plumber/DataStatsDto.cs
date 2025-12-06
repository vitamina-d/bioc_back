using System.Text.Json.Serialization;

namespace Domain.DTO.Plumber
{
    public class DataStatsDto
    {
        [JsonPropertyName("length")]
        public int Lenght { get; set; }
        [JsonPropertyName("nucleotides")]
        public Nucleotides Nucleotides { get; set; }
        [JsonPropertyName("cpg_islands")]
        public CpgIslandsDto? CpgIslands { get; set; }
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }

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
"data": {
    "complete": true,
    "sequence": "TA",
    "length": 24676,
    "nucleotides": {
        "A": 5736,
        "C": 6459,
        "G": 6302,
        "T": 6179,
        "other": 0
    },
    "cpg_islands": {
        "count": 528,
        "start": [ ]
    }
  }
}
}*/
