using System.Text.Json.Serialization;

namespace Domain.DTO.Folding
{
    public class PLDDTNeurosnapDto
    {
        [JsonPropertyName("plddt")]
        public double[] pLDDT { get; set; }
        [JsonPropertyName("max_pae")] 
        public double MaxPae { get; set; }
        [JsonPropertyName("pae")] 
        public double[][] Pae { get; set; }
        [JsonPropertyName("ptm")] 
        public double Ptm { get; set; }
    }
}
