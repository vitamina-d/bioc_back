using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class EnsemblResponseDto
    {
        [JsonPropertyName("query")]
        public string Query { get; set; }
        [JsonPropertyName("seq")]
        public string Seq { get; set; }
        [JsonPropertyName("molecule")]
        public string Molecule { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}

/*
{
  "query": "11:100000..100100",
  "seq": "TGGGAGCTACAATTCAAGATGAGATTTGGGAAAGGACACAGCCAAACCACCTCATTCTGCCTCTGGCACCTCCCAAATCTCATGTCCTCACATTTCAAAAC",
  "molecule": "dna",
  "id": "chromosome:GRCh38:11:100000:100100:1"
}
*/
