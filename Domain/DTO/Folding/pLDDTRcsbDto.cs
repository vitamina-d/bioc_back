using System.Text.Json.Serialization;

namespace Domain.DTO.Folding
{
    public class PLDDTRcsbDto
    {
        [JsonPropertyName("residueNumber")]
        public int[] ResidueNumber { get; set; }
        [JsonPropertyName("confidenceScore")]
        public double[] ConfidenceScore { get; set; }
        [JsonPropertyName("confidenceCategory")]
        public string[] ConfidenceCategory { get; set; }
    }
}
