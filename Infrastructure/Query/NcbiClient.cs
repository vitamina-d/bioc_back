using Domain;
using Infrastructure.Query;
using System.Text.RegularExpressions;

namespace Application
{
    public class NcbiClient : BaseClient, INcbiClient
    {        
        public NcbiClient(HttpClient httpClient) : base(httpClient) { }
        
        //PUT
        public async Task<string> InitJob(string nucleotides)
        {
            var url = "Blast.cgi";
            var form = new Dictionary<string, string>
            {
                ["CMD"] = "Put",
                ["PROGRAM"] = "blastx",
                ["DATABASE"] = "swissprot", //nr no devuelve un id
                ["QUERY"] = nucleotides,
                ["FORMAT_TYPE"] = "JSON2"
            };

            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.PutAsync(url, new FormUrlEncodedContent(form));
            }, url);

            //var line = System.Text.RegularExpressions.Regex.Match(response, "RID = (\\S+)");//
            var line = Regex.Match(response, @"RID\s*=\s*([A-Z0-9]+)");
            var rid = line.Groups[1].Value;
            return rid; //{RID = GU0F7BRA014}
        }

        //GET
        public async Task<string> GetRidStatus(string rid)
        {
            var url = $"Blast.cgi?CMD=Get&FORMAT_OBJECT=SearchInfo&RID={rid}";

            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);

            // QBlastInfoBegin Status=WAITING QBlastInfoEnd  o Status=READY
            var line = Regex.Match(response, @"Status\s*=\s*(\w+)");
            return line.Groups[1].Value; //WAITING, RUNNING, READY, FAILED o UNKNOWN
        }

        public async Task<string> GetResultRid(string rid)
        {
            //https://blast.ncbi.nlm.nih.gov/Blast.cgi?CMD=GetSaved&RECENT_RESULTS=on&RID=GTGHJNKZ014&DOWNLOAD_OPTIONS=true
            //https://blast.ncbi.nlm.nih.gov/blast/Blast.cgi?CMD=Get&RID=GTGHJNKZ014&FORMAT_TYPE=XML

            var url = $"Blast.cgi?CMD=Get&RID={rid}&FORMAT_TYPE=XML";
            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);

            return response;
        }
    }
}