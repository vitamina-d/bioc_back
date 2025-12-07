using Domain.Interfaces;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Query
{
    public class BlastClient(HttpClient httpClient) : BaseClient(httpClient), IBlastClient
    {
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
