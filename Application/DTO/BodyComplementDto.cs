using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class BodyComplementDto
    {
        [JsonPropertyName("seq")]
        public string Sequence { get; set; }
        [JsonPropertyName("to_reverse")]
        public bool ToReverse { get; set; }
        [JsonPropertyName("to_complement")]
        public bool ToComplement { get; set; }
    }
}
/*
#* @param seq Secuencia
#* @param reverse:boolean 
#* @param complement:boolean 

 */