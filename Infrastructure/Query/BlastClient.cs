using Infrastructure.Query;
using System.Text;
using System.Text.Json;

namespace Application
{
    public class BlastClient : BaseClient, IBlastClient
    {
        public BlastClient(HttpClient httpClient) : base(httpClient) { }
        public async Task<string> BlastX(string sequence)
        {
            var url = "blastx/";
            var body = new
            {
                sequence = sequence
            };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.PostAsync(url, content);
            }, url);
            return response;
        }
    }
}
