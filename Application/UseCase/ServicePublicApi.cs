using Application.DTO;
using System.Text.Json;

namespace Application
{
    public class ServicePublicApi : IServicePublicApi
    {
        private readonly IPublicApiClient _publicApiClient;

        public ServicePublicApi(IPublicApiClient publicApiClient)
        {
            _publicApiClient = publicApiClient;
        }

        public async Task<EnsemblResponseDto> GetSequenceFromEnsembl(string chrom, int start, int end)
        {
            var response = await _publicApiClient.GetEnsemblResponse(chrom, start, end);
            return response;
        }

        public async Task<NcbiResponseDto> GetSummaryFromNcbi(string entrez, string type)
        {
            var response = await _publicApiClient.GetNcbiResponse(entrez, type);
            var json = JsonDocument.Parse(response);
            var nodo = json.RootElement.GetProperty("result").GetProperty(entrez);

            //llegan en minuscula
            return (new NcbiResponseDto
            {
                EntrezId = entrez,
                Name = nodo.GetProperty("name").GetString(),
                MapLocation = nodo.GetProperty("maplocation").GetString(),
                Description = nodo.GetProperty("description").GetString(),
                Summary = nodo.GetProperty("summary").GetString(),
                Scientificname = nodo.GetProperty("organism").GetProperty("scientificname").GetString(),
                TaxId = nodo.GetProperty("organism").GetProperty("taxid").GetInt16(),
            });
        }
    }
}
