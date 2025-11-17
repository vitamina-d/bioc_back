using System.Text.Json.Serialization;

namespace Application.DTO.Folding
{
    public class pLDDTNeurosnapDto
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
