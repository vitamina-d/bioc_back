namespace Application.DTO
{
    public class SeqBySymbolResponseDto
    {
        public string Status { get; set; }
        public double Time_Secs { get; set; }
        public SequenceDataDto Data { get; set; }

    }
}
/*
    {
      "status": "success",
      "time_secs": 2.2354,
      "data": {
        "type": "complete",
        "sequence_length": 24676,
        "sequence": "AT"
      }
    }
*/