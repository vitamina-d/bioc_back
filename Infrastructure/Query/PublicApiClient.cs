using Application;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Query
{
    public class PublicApiClient : IPublicApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;


        public PublicApiClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<byte[]> DownloadPdb(string pdbId)
        {
            var _rcsbURL = _configuration["API_URL:RCSB"];
            var url = $"{_rcsbURL}download/{pdbId}.pdb"; ///https://files.rcsb.org/download/1gav.pdb
            try
            {
                var pdb = await _httpClient.GetByteArrayAsync(url);
                return pdb;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error HTTP {_rcsbURL}: {ex.Message}", ex);
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"Timeout: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado: {ex.Message}", ex);
            }
        }

       public async Task<string> GetNcbiResponse(string entrez, string type)
        {
            //https://eutils.ncbi.nlm.nih.gov/entrez/eutils/esummary.fcgi?db=gene&id=1717&retmode=json
            var _ncbiURL = _configuration["API_URL:NCBI"]; // "https://eutils.ncbi.nlm.nih.gov/";
            string url = $"{_ncbiURL}entrez/eutils/esummary.fcgi?db={type}&id={entrez}&retmode=json";
            
            try
            {
                var response = await _httpClient.GetStringAsync(url);
                return response;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error HTTP {_ncbiURL}: {ex.Message}", ex);
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"Timeout: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado: {ex.Message}", ex);
            }
        }
    }
}
