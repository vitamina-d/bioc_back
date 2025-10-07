using System.Text.Json.Serialization;

namespace Application.DTO.Plumber
{

    public class DataSequenceDto
    {
        [JsonPropertyName("entrez")]
        public string? Entrez { get; set; } 
        [JsonPropertyName("complete")]
        public bool Complete { get; set; } //complete / exons
        [JsonPropertyName("sequences_count")]
        public int SequencesCount { get; set; }
        [JsonPropertyName("sequences")]
        public string[] Sequences { get; set; }
    }
}
