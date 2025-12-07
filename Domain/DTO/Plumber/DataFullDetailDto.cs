using System.Text.Json.Serialization;

namespace Domain.DTO.Plumber
{
    public class DataFullDetailDto : DataDetailDto
    {
        [JsonPropertyName("citogenetic")]
        public string Cytogenetic { get; set; }
        [JsonPropertyName("location")]
        public LocationDto[] Location { get; set; }
        [JsonPropertyName("ensembl_id_gene")]
        public string[] EnsemblIdGene { get; set; }
        [JsonPropertyName("ensembl_id_protein")]
        public string[] EnsemblIdProtein { get; set; }
        [JsonPropertyName("uniprot_ids")]
        public string[] Uniprot_Ids { get; set; } 

    }
    public class LocationDto
    {
        [JsonPropertyName("strand")]
        public string Strand { get; set; }
        [JsonPropertyName("seqnames")]
        public string Seqnames { get; set; }
        [JsonPropertyName("start")]
        public int Start { get; set; }
        [JsonPropertyName("end")]
        public int End { get; set; }
        [JsonPropertyName("length")]
        public int Length { get; set; }
    }
}
