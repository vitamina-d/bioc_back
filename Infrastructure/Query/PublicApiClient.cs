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
        public async Task<string> DownloadPdb(string pdbId)
        {
            var _rcsbURL = _configuration["API_URL:RCSB"];
            var url = $"{_rcsbURL}download/{pdbId}.pdb"; ///https://files.rcsb.org/download/1gav.pdb
            var pdb = await _httpClient.GetStringAsync(url);
            return pdb;
        }

       public async Task<string> GetNcbiResponse(string entrez, string type)
        {
            // xml o json
            //https://eutils.ncbi.nlm.nih.gov/entrez/eutils/esummary.fcgi?db=gene&id=1717&retmode=json
            var _ncbiURL = _configuration["API_URL:NCBI"]; // "https://eutils.ncbi.nlm.nih.gov/";
            string url = $"{_ncbiURL}entrez/eutils/esummary.fcgi?db={type}&id={entrez}&retmode=json";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }
    }
}
