using System.Text.Json.Serialization;

namespace Application.DTO.Folding
{
    public class pLDDTRcsbDto
    {
        [JsonPropertyName("residueNumber")]
        public int[] ResidueNumber { get; set; }
        [JsonPropertyName("confidenceScore")]
        public double[] ConfidenceScore { get; set; }
        [JsonPropertyName("confidenceCategory")]
        public string[] ConfidenceCategory { get; set; }
    }
}
