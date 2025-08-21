using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class DetailResponseDto
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("time_secs")]
        public double Time_Secs { get; set; }
        [JsonPropertyName("data")]
        public DetailDataDto Data { get; set; }

    }

    public class DetailDataDto
    {
        [JsonPropertyName("entrezID")]
        public string EntrezID { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("location")]
        public LocationDto Location { get; set; }
        [JsonPropertyName("length")]
        public int Length { get; set; }
        [JsonPropertyName("strand")]
        public string Strand { get; set; } //+ o -
        [JsonPropertyName("ensembl_id_gene")]
        public string EnsemblIdGene { get; set; }
        [JsonPropertyName("ensembl_id_protein")]
        public string EnsemblIdProtein { get; set; }
        [JsonPropertyName("uniprot_ids")]
        public string[] Uniprot_Ids { get; set; } 

    }
    public class LocationDto
    {
        [JsonPropertyName("citogenetic")]
        public string Cytogenetic { get; set; } //     "location_chr": "11q13.4",
        [JsonPropertyName("chr")]
        public string Chr { get; set; }         //     "chr": "chr11",
        [JsonPropertyName("start")]
        public int Start { get; set; }
        [JsonPropertyName("end")]
        public int End { get; set; }
    }
}

/*
         {
  "status": "success",
  "time_secs": 2.8033,
  "data": {
    "entrezID": "1717",
    "symbol": "DHCR7",
    "type": "protein-coding",
    "location_chr": "11q13.4",
    "chr": "chr11",
    "start": 71428193,
    "end": 71452868,
    "length": 24676,
    "strand": "-",
    "ensembl_id_gene": "ENSG00000172893",
    "ensembl_id_protein": null,
    "uniprot_id": []
  }
}
         */