using System.Text.Json.Serialization;

namespace Application.DTO.Folding
{
    public class DataRanksDto
    {
        [JsonPropertyName("protein")]
        public Dictionary<string, double> Protein { get; set; }
    }
}
