using System.Text.Json.Serialization;

namespace Domain.DTO.Folding
{
    public class DataRanksDto
    {
        [JsonPropertyName("prot1")]
        public Dictionary<string, double> Prot1 { get; set; }
    }
}
