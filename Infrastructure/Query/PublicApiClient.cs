using Application;
using Application.DTO;
using System.Net.Http.Json;

namespace Infrastructure.Query
{
    public class PublicApiClient : IPublicApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _ensemblURL;
        private readonly string _ncbiURL;


        public PublicApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _ensemblURL = "https://rest.ensembl.org/";
            _ncbiURL = "https://eutils.ncbi.nlm.nih.gov/";
        }

        public async Task<EnsemblResponseDto> GetEnsemblResponse(string chrom, int start, int end)
        {
            //fasta o json
            //https://rest.ensembl.org/sequence/region/human/11:100000..100100?content-type=application/json";
            string url = $"{_ensemblURL}sequence/region/human/{chrom}:{start}..{end}?content-type=application/json"; 
            var response = await _httpClient.GetFromJsonAsync<EnsemblResponseDto>(url);
            return response;
        }

        public async Task<string> GetNcbiResponse(string entrez, string type)
        {
            // xml o json
            //https://eutils.ncbi.nlm.nih.gov/entrez/eutils/esummary.fcgi?db=gene&id=1717&retmode=json
            string url = $"{_ncbiURL}entrez/eutils/esummary.fcgi?db={type}&id={entrez}&retmode=json";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }
    }
}
