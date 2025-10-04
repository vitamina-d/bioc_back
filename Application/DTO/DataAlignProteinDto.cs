using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class DataAlignProteinDto
    {
        [JsonPropertyName("prediction_pdb")]
        public string Prediction { get; set; }
        [JsonPropertyName("reference_pdb")]
        public string ReferencePdb { get; set; }
    }
}
