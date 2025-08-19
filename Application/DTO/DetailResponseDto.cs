namespace Application.DTO
{
    public class DetailResponseDto
    {
        public string Status { get; set; }
        public double Time_Secs { get; set; }
        public AlignDataDto Data { get; set; }

    }

    public class DetailDataDto
    {
        public string EntrezID { get; set; }
        public string Symbol { get; set; }
        public string Type { get; set; }
        public LocationDto Location { get; set; }
        public int Length { get; set; }
        public string Strand { get; set; } //+ o -
        public string EnsemblIdGene { get; set; } 
        public string EnsemblIdProtein { get; set; } 
        public string[] Uniprot_Ids { get; set; } 

    }
    public class LocationDto
    {
        public string Cytogenetic { get; set; } //     "location_chr": "11q13.4",
        public string Chr { get; set; }         //     "chr": "chr11",
        public int Start { get; set; }
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