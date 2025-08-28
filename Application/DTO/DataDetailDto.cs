using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class DataDetailDto
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("entrezID")]
        public string EntrezID { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("location")]
        public LocationDto Location { get; set; }

        [JsonPropertyName("ensembl_id_gene")]
        public string[] EnsemblIdGene { get; set; }
        [JsonPropertyName("ensembl_id_protein")]
        public string[] EnsemblIdProtein { get; set; }
        [JsonPropertyName("uniprot_ids")]
        public string[] Uniprot_Ids { get; set; } 

    }
    public class LocationDto
    {
        [JsonPropertyName("citogenetic")]
        public string Cytogenetic { get; set; } //     "location_chr": "11q13.4",
        [JsonPropertyName("strand")]
        public string Strand { get; set; } //+ o -
        [JsonPropertyName("chr")]
        public string Chr { get; set; }         //     "chr": "chr11",
        [JsonPropertyName("start")]
        public int Start { get; set; }
        [JsonPropertyName("end")]
        public int End { get; set; }
        [JsonPropertyName("length")]
        public int Length { get; set; }
    }
}

/*
data = list(
            message = "Ok",
            entrezID = entrez,
            symbol = unique(details$SYMBOL),
            type = unique(details$GENETYPE),
            location = list(
                citogenetic = unique(details$MAP),
                strand = as.character(range_df$strand),
                chr = as.character(range_df$seqnames),
                start = range_df$start,
                end = range_df$end,
                length = range_df$width
            ),
            ensembl_id_gene = unique(details$ENSEMBL),
            ensembl_id_protein = unique(details$ENSEMBLPROT),
            uniprot_ids = unique(details$UNIPROT)
          )
data = list(
             message = "Ok",
            entrez = entrez,
            symbol = unique(details$SYMBOL),
            genetype = unique(details$GENETYPE),
            alias = unique(details$ALIAS)
 
 */