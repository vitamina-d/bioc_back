using System.Text.Json.Serialization;

namespace Domain.DTO.Folding
{
    public class UniprotDto
    {
        [JsonPropertyName("features")]
        public Feature[]? Features { get; set; } //para buscar pdb ids

        [JsonPropertyName("uniProtKBCrossReferences")]
        public CrossReference[]? UniProtKBCrossReferences { get; set; } //para buscar csm alphafold
    }

    public class Feature
    {
        [JsonPropertyName("evidences")]
        public Evidence[]? Evidences { get; set; }
    }

    public class Evidence
    {
        [JsonPropertyName("evidenceCode")]
        public string? EvidenceCode { get; set; }

        [JsonPropertyName("source")]
        public string? Source { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }
    public class CrossReference
    {
        [JsonPropertyName("database")]
        public string? Database { get; set; }
        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }
}