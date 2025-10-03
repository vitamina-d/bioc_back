using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class DataEntrezDto
    {
        [JsonPropertyName("entrez")]
        public string Entrez { get; set; }
    }
}
/*
    {
        "status": "success",
        "time_secs": 0.4927,
        "data": {
            "value": "DHCR7",
            "label": "SYMBOL",
            "entrez": "1717"
            }
    }
    */