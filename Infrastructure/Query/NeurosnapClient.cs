using Infrastructure.Query;
using System;
using System.Text;
using System.Text.Json;

namespace Application
{
    public class NeurosnapClient : BaseClient, INeurosnapClient
    {        
        public NeurosnapClient(HttpClient httpClient) : base(httpClient) { }
        
        //POST
        public async Task<string> InitJob(string aminoAcidSequence)
        {
            ///api/job/submit/SERVICE_NAME?note=NOTE multipart/form-data
            var url = "api/job/submit/AlphaFold2?note=vitamina";

            // multipart
            var content = new MultipartFormDataContent
            {
                {
                    new StringContent(
                        JsonSerializer.Serialize(new
                        {
                            aa = new Dictionary<string, string> { { "protein", aminoAcidSequence } },
                            dna = new { },
                            rna = new { }
                        }),
                        Encoding.UTF8,
                        "application/json"
                    ),
                    "Input Sequences"
                },
                { new StringContent("auto"), "Model Type" },//
                { new StringContent("none"), "Template Mode" },//no usar homologos
                { new StringContent("mmseqs2_uniref_env"), "MSA Mode" },
                { new StringContent("unpaired_paired"), "Pair Mode" },
                { new StringContent("5"), "Number Recycles" }, //el modelo refina 5 veces la prediccion
                { new StringContent("0.75"), "Recycles Early Stop Tolerance" }, //no refinar si no mejora
                { new StringContent("1"), "Number Ensembles" }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = content;
            var response = await HandlerTryCatch(async () =>
            {
                var httpResponse = await _httpClient.SendAsync(request);
                httpResponse.EnsureSuccessStatusCode(); //HttpRequestException
                return await httpResponse.Content.ReadAsStringAsync();
            }, url);
            return response; // "\"68e17d82e986d44f8b7e9e1b\""
        }

        //GET
        public async Task<string> GetJobStatus(string jobId)
        {
            var url = $"api/job/status/{jobId}";
            return await HandlerTryCatch(() => _httpClient.GetStringAsync(url), url);
        }

        public async Task<string> GetJobs()
        {
            var url = "api/jobs";
            return await HandlerTryCatch(() => _httpClient.GetStringAsync(url), url);
        }

        public async Task<string> GetRanks(string jobId)
        {
            var url = $"api/job/file/{jobId}/out/uncertainty.json";
            return await HandlerTryCatch(() => _httpClient.GetStringAsync(url), url); //min = best prediction 
            //{"prot1": {"1": 7.8, "2": 4.97, "3": 4.71, "4": 5.85, "5": 6.44}} rank_1 al 5
        }

        //BYTE
        public async Task<byte[]> GetPrediction(string jobId, string rank)
        {
            //api/job/file/JOB_ID/[in/out]/FILE_NAME?share=SHARE_ID;
            var url = $"api/job/file/{jobId}/out/prot1_rank_{rank}.pdb";//ok
            return await HandlerTryCatch(() => _httpClient.GetByteArrayAsync(url), url);
        }
    }
}