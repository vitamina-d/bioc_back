namespace Application.DTO
{
    public class PercentResponseDto
    {
        public string Status { get; set; }
        public double Time_Secs { get; set; }
        public PercentDataDto Data { get; set; }

    }

    public class PercentDataDto
    {
        public CompositionDto Composition { get; set; }
        public CpgIslandsDto CpgIslands { get; set; }

    }
    public class CompositionDto
    {
        public NucleotidesDto Nucleotides { get; set; }
        public int Total { get; set; }
        public double AtPercent { get; set; }
        public double CgPercent { get; set; }
    }

    public class NucleotidesDto
    {
        public string[] Labels {  get; set; }
        public int[] Counts { get; set; }
    }

    public class CpgIslandsDto
    {
        public int Length { get; set; } 
        public RangesDto Ranges { get; set; }
    }

    public class RangesDto
    {
        public int Start { get; set; }
        public int End { get; set; }
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