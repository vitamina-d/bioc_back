using System.Text.Json.Serialization;

namespace Application.DTO.Plumber
{
    public class DataStatsDto
    {
        [JsonPropertyName("complete")]
        public bool Complete { get; set; }
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
        [JsonPropertyName("length")]
        public int Lenght { get; set; }
        [JsonPropertyName("nucleotides")]
        public Nucleotides Nucleotides { get; set; }
        [JsonPropertyName("cpg_islands")]
        public CpgIslandsDto? CpgIslands { get; set; }

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
