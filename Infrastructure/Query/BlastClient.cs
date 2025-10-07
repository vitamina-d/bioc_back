using System.Text;
using System.Text.Json;

namespace Application
{
    public class BlastClient : IBlastClient
    {
        private readonly HttpClient _httpClient;
        public BlastClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> BlastX(string sequence)
        {
            var url = "blastx/";
            var body = new
            {
                sequence = sequence
            };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
