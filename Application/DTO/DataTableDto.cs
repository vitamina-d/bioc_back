using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class DataTableDto 
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("table")]
        public RowDto[] Table { get; set; }

    }
    public class RowDto
    {

        [JsonPropertyName("ENTREZID")]
        public string EntrezId { get; set; }
        [JsonPropertyName("SYMBOL")]
        public string Symbol { get; set; }

    }
}

/*
    return(list(
        code = 200,
        datetime = start_time,
        time_secs = time,
        data = list (
            count = nrow(select),
            table = select
            )
        )
    )
    "rows": [
      {
        "ENTREZID": "1",
        "SYMBOL": "A1BG"
      }, ...
      ]
 */