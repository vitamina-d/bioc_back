using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class DataDetailDto
    {
        [JsonPropertyName("entrez")]
        public string Entrez { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("genetype")]
        public string Genetype { get; set; }
        [JsonPropertyName("alias")]
        public string[] Alias { get; set; }
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