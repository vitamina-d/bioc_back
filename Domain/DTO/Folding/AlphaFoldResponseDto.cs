using System.Text.Json.Serialization;

namespace Domain.DTO.Folding
{
    public class AlphaFoldResponseDto
    {
        [JsonPropertyName("result_set")]
        public ResultSetDto[] ResultSet { get; set; }
    }
    public class ResultSetDto
    {
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }
        [JsonPropertyName("score")]
        public double Score { get; set; }

    }
}
/*
 { "query_id" : "36b7263a-f074-4b3d-a8ee-19ed75b5f391", 
"result_type" : "entry", 
"total_count" : 1, 
"result_set" : [ 
{ "identifier" : "AF_AFQ7SXF1F1", "score" : 1.0 } ] }
 */