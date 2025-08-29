using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class DataEntrezDto
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
        [JsonPropertyName("label")]
        public string Label { get; set; }
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