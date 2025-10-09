namespace Application.DTO.Public
{
    public class ResponseUncertaintyDto
    {

        public string Protein { get; set; }
        public List<RankDto> Ranks { get; set; }
    }

    public class RankDto
    {
        public int Rank { get; set; }
        public double Value { get; set; } //incertidumbre 

    }
}

