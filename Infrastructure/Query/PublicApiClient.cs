using Application;
using Domain.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Query
{
    public class PublicApiClient : BaseClient, IPublicApiClient
    {
        private readonly IConfiguration _configuration;

        public PublicApiClient(HttpClient httpClient, IConfiguration configuration) : base(httpClient)
        {
            _configuration = configuration;
        }
        //GET
        public async Task<string> GetNcbiResponse(string entrez, string type)
        {
            var _ncbiURL = _configuration["API_URL:NCBI"]; 
            string url = $"{_ncbiURL}entrez/eutils/esummary.fcgi?db={type}&id={entrez}&retmode=json";
            
            return await HandlerTryCatch(() => _httpClient.GetStringAsync(url), url);
        }

        //BYTE
        public async Task<byte[]> DownloadPdb(string pdbId)
        {
            var _rcsbURL = _configuration["API_URL:RCSB"];
            var url = $"{_rcsbURL}download/{pdbId}.pdb"; 
            return await HandlerTryCatch(() => _httpClient.GetByteArrayAsync(url), url);
        }
    }
}
