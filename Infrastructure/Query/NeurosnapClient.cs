using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace Application
{
    public class NeurosnapClient : INeurosnapClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _neurosnapURL;

        public NeurosnapClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _neurosnapURL = configuration["API_URL:NEUROSNAP"];
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("X-API-KEY", configuration["NeuroSnap:API_KEY"]);
        }

        public async Task<string> InitJob(string aminoAcidSequence)
        {
            ///api/job/submit/SERVICE_NAME?note=NOTE multipart/form-data
            var url = $"{_neurosnapURL}/api/job/submit/AlphaFold2?note=vitamina";

            // multipart
            var content = new MultipartFormDataContent
            {
                {
                    new StringContent(
                        JsonSerializer.Serialize(new
                        {
                            aa = new Dictionary<string, string> { { "prot1", aminoAcidSequence } },
                            dna = new { },
                            rna = new { }
                        }),
                        Encoding.UTF8,
                        "application/json"
                    ),
                    "Input Sequences"
                },
                { new StringContent("auto"), "Model Type" },
                { new StringContent("none"), "Template Mode" },
                { new StringContent("mmseqs2_uniref_env"), "MSA Mode" },
                { new StringContent("unpaired_paired"), "Pair Mode" },
                { new StringContent("5"), "Number Recycles" },
                { new StringContent("0.75"), "Recycles Early Stop Tolerance" },
                { new StringContent("1"), "Number Ensembles" }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return json; // "\"68e17d82e986d44f8b7e9e1b\""
        }

        public async Task<string> GetJobStatus(string jobId)
        {
            ///api/job/status/JOB_ID; pending, running, failed, and completed
            var url = $"{_neurosnapURL}/api/job/status/{jobId}";
            return await _httpClient.GetStringAsync(url);
        }

        public async Task<string> GetPrediction(string jobId)
        {
            ///api/job/file/JOB_ID/[in/out]/FILE_NAME?share=SHARE_ID;
            var pdbUrl = $"{_neurosnapURL}/api/job/file/{jobId}/out/prot1_rank_1.pdb";
            var pdbResponse = await _httpClient.GetStringAsync(pdbUrl);
            
            var jsonUrl = $"{_neurosnapURL}/api/job/file/{jobId}/out/prot1_rank_1.json";
            var jsonResponse = await _httpClient.GetStringAsync(jsonUrl);
            
            return pdbResponse;
        }
        public async Task<string> GetJobs()
        {
            var url = $"{_neurosnapURL}/api/jobs";
            return await _httpClient.GetStringAsync(url);
        }
    }
}
