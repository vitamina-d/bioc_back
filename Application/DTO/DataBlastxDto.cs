using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class DataBlastxDto
    {
        [JsonPropertyName("BlastOutput2")]
        public List<BlastOutput2> BlastOutput2 { get; set; }
    }

    public class BlastOutput2
    {
        [JsonPropertyName("report")]
        public Report Report { get; set; }
    }

    public class Report
    {
        [JsonPropertyName("program")]
        public string Program { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("search_target")]
        public SearchTarget SearchTarget { get; set; }

        [JsonPropertyName("params")]
        public Params Params { get; set; }

        [JsonPropertyName("results")]
        public Results Results { get; set; }
    }

    public class SearchTarget
    {
        [JsonPropertyName("db")]
        public string Db { get; set; }
    }

    public class Params
    {
        [JsonPropertyName("matrix")]
        public string Matrix { get; set; }

        [JsonPropertyName("expect")]
        public double Expect { get; set; }

        [JsonPropertyName("gap_open")]
        public int GapOpen { get; set; }

        [JsonPropertyName("gap_extend")]
        public int GapExtend { get; set; }

        [JsonPropertyName("filter")]
        public string Filter { get; set; }

        [JsonPropertyName("cbs")]
        public int Cbs { get; set; }

        [JsonPropertyName("query_gencode")]
        public int QueryGencode { get; set; }
    }

    public class Results
    {
        [JsonPropertyName("search")]
        public Search Search { get; set; }
    }

    public class Search
    {
        [JsonPropertyName("query_id")]
        public string QueryId { get; set; }

        [JsonPropertyName("query_len")]
        public int QueryLen { get; set; }

        [JsonPropertyName("query_masking")] //cuando hay hits
        public List<QueryMasking>? QueryMasking { get; set; }

        [JsonPropertyName("hits")]
        public List<Hit> Hits { get; set; }

        [JsonPropertyName("stat")]
        public Stat Stat { get; set; }

        [JsonPropertyName("message")] // cuando no hay hits
        public string? Message { get; set; }
    }

    public class QueryMasking
    {
        [JsonPropertyName("from")]
        public int From { get; set; }

        [JsonPropertyName("to")]
        public int To { get; set; }
    }

    public class Hit
    {
        [JsonPropertyName("num")]
        public int Num { get; set; }

        [JsonPropertyName("description")]
        public List<Description> Description { get; set; }

        [JsonPropertyName("len")]
        public int Len { get; set; }

        [JsonPropertyName("hsps")]
        public List<Hsp> Hsps { get; set; }
    }

    public class Description
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("accession")]
        public string Accession { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("taxid")]
        public int Taxid { get; set; }
    }

    public class Hsp
    {
        [JsonPropertyName("num")]
        public int Num { get; set; }

        [JsonPropertyName("bit_score")]
        public double BitScore { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("evalue")]
        public double Evalue { get; set; }

        [JsonPropertyName("identity")]
        public int Identity { get; set; }

        [JsonPropertyName("positive")]
        public int Positive { get; set; }

        [JsonPropertyName("query_from")]
        public int QueryFrom { get; set; }

        [JsonPropertyName("query_to")]
        public int QueryTo { get; set; }

        [JsonPropertyName("query_frame")]
        public int QueryFrame { get; set; }

        [JsonPropertyName("hit_from")]
        public int HitFrom { get; set; }

        [JsonPropertyName("hit_to")]
        public int HitTo { get; set; }

        [JsonPropertyName("align_len")]
        public int AlignLen { get; set; }

        [JsonPropertyName("gaps")]
        public int Gaps { get; set; }

        [JsonPropertyName("qseq")]
        public string Qseq { get; set; }

        [JsonPropertyName("hseq")]
        public string Hseq { get; set; }

        [JsonPropertyName("midline")]
        public string Midline { get; set; }
    }

    public class Stat
    {
        [JsonPropertyName("db_num")]
        public int DbNum { get; set; }

        [JsonPropertyName("db_len")]
        public long DbLen { get; set; }

        [JsonPropertyName("hsp_len")]
        public int HspLen { get; set; }

        [JsonPropertyName("eff_space")]
        public long EffSpace { get; set; }

        [JsonPropertyName("kappa")]
        public double Kappa { get; set; }

        [JsonPropertyName("lambda")]
        public double Lambda { get; set; }

        [JsonPropertyName("entropy")]
        public double Entropy { get; set; }
    }
}


/*

{
  "code": 1,
  "message": "msg",
  "data": {
    "BlastOutput2": [
      {
        "report": {
          "program": "blastx",
          "version": "BLASTX 2.17.0+",
          "reference": "Stephen F. Altschul, Thomas L. Madden, Alejandro A. Sch&auml;ffer, Jinghui Zhang, Zheng Zhang, Webb Miller, and David J. Lipman (1997), \"Gapped BLAST and PSI-BLAST: a new generation of protein database search programs\", Nucleic Acids Res. 25:3389-3402.",
          "search_target": {
            "db": "/blast/blastdb/pdbaa"
          },
          "params": {
            "matrix": "BLOSUM62",
            "expect": 10,
            "gap_open": 11,
            "gap_extend": 1,
            "filter": "L;",
            "cbs": 2,
            "query_gencode": 1
          },
          "results": {
            "search": {
              "query_id": "Query_1",
              "query_len": 4,
              "hits": [],
              "stat": {
                "db_num": 175660,
                "db_len": 50420939,
                "hsp_len": 0,
                "eff_space": 50420939,
                "kappa": 0.041,
                "lambda": 0.267,
                "entropy": 0.14
              },
              "message": "No hits found"
            }
          }
        }
      }
    ]
  }
}
                 */
