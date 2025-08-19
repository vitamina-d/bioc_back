namespace Application.DTO
{
    public class SeqByRangeResponseDto
    {
        public string Status { get; set; }
        public double Time_Secs { get; set; }
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