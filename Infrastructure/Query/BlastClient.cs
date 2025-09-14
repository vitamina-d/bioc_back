using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Application
{
    public class BlastClient : IBlastClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _blastURL;

        public BlastClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _blastURL = configuration["API_URL:BLAST"];
        }

        public async Task<string> BlastP(string sequence)
        {
            //var url = $"{_blastURL}/echo/?msg=HELLO";
            var url = $"{_blastURL}/blastp/";
            var body = new { sequence = sequence };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> BlastX(string sequence)
        {
            var url = $"{_blastURL}/blastx/";
            //var result = await _httpClient.GetStringAsync(url);
            var body = new
            {
                sequence = sequence
            };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> GetEcho(string msg)
        {
            var url = $"{_blastURL}/echo/?msg={Uri.EscapeDataString(msg)}";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }
    }
}
