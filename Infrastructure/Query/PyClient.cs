using Microsoft.Extensions.Configuration;

namespace Application
{
    public class PyClient : IPyClient
    {
        private readonly HttpClient _httpClient;
        //private readonly string _biopURL;
        public PyClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            //_biopURL = configuration["API_URL:BIOPY"];
        }
        public async Task<string> GetAminoAcidSeq(string sequence, string frame)
        {
            var url = "aminoacid";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }

        public async Task<string> GetAlignProtein(string prediction, string reference)
        {
            var url = "align";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }
    }
}
