using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class PercentResponseDto
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("time_secs")]
        public double Time_Secs { get; set; }
        [JsonPropertyName("data")]
        public PercentDataDto Data { get; set; }

    }

    public class PercentDataDto
    {
        [JsonPropertyName("composition")]
        public CompositionDto Composition { get; set; }
        [JsonPropertyName("cpg_islands")]
        public CpgIslandsDto CpgIslands { get; set; }

    }
    public class CompositionDto
    {
        [JsonPropertyName("nucleotides")]
        public NucleotidesDto Nucleotides { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("at_percent")]
        public double AtPercent { get; set; }
        [JsonPropertyName("cg_percent")]
        public double CgPercent { get; set; }
    }

    public class NucleotidesDto
    {
        [JsonPropertyName("labels")]
        public string[] Labels {  get; set; }
        [JsonPropertyName("counts")]
        public int[] Counts { get; set; }
    }

    public class CpgIslandsDto
    {
        [JsonPropertyName("length")]
        public int Length { get; set; }
        [JsonPropertyName("ranges")]
        public RangesDto[] Ranges { get; set; }
    }

    public class RangesDto
    {
        [JsonPropertyName("start")]
        public int Start { get; set; }
        [JsonPropertyName("end")]
        public int End { get; set; }
        [JsonPropertyName("width")]
        public int Width { get; set; }
    }
}

//[JsonPropertyName("at_percent")]
/*
  result <- list(
    status = "success", 
    time_secs = time,
    data = list(
      composition = list(
        nucleotides = list(
          labels = c("A", "T", "C", "G"),
          counts = c(
            as.integer(counter_base["A"]),
            as.integer(counter_base["T"]),
            as.integer(counter_base["C"]),
            as.integer(counter_base["G"])
          )
        ),
        total = total,
        at_percent = at_percent,
        cg_percent = cg_percent,
      ),
      cpg_islands = list(
        length = counter_CpG,
        ranges = cpg_info
      )
    )
  )
*/