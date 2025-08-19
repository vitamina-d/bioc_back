namespace Application.DTO
{
    public class AlignResponseDto
    {
        public string Status { get; set; }
        public double Time_Secs { get; set; }
        public AlignDataDto Data { get; set; }

    }

    public class AlignDataDto
    {
        public double Score { get; set; }
        public string Type { get; set; }
        public string Pattern { get; set; }
        public string Subject { get; set; }
        public string Pattern_Align { get; set; }
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
