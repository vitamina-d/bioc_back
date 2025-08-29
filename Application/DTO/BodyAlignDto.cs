using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class BodyAlignDto
    {
        [JsonPropertyName("pattern")]
        public string Pattern { get; set; }
        [JsonPropertyName("subject")]
        public string Subject { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; } //#* @param type "global", "local", "overlap"
        [JsonPropertyName("gapOpening")]
        public int GapOpening { get; set; }
        [JsonPropertyName("gapExtension")]
        public int GapExtension { get; set; }

    }
}
/*
 #* @param pattern Lectura
#* @param subject Genoma de referencia
#* @param type "global", "local", "overlap"
#* @param gapOpening number
#* @param gapExtension number
 */