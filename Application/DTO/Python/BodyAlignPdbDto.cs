using System.Text.Json.Serialization;

namespace Application.DTO.Python
{
    public class BodyAlignPdbDto
    {
        [JsonPropertyName("prediction_pdb")]
        public string PredictionPdb { get; set; }
        [JsonPropertyName("reference_pdb")]
        public string ReferencePdb { get; set; }
    }
}
//python