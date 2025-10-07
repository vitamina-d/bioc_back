using Application.DTO.Public;
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
        public async Task<ResponseNcbiDto> GetSummaryFromNcbi(string entrez, string type)
        {
            var response = await _publicApiClient.GetNcbiResponse(entrez, type);
            var json = JsonDocument.Parse(response);
            var nodo = json.RootElement.GetProperty("result").GetProperty(entrez);

            //llegan en minuscula
            return (new ResponseNcbiDto
            {
                Name = nodo.GetProperty("name").GetString(),
                Description = nodo.GetProperty("description").GetString(),
                Summary = nodo.GetProperty("summary").GetString(),
                Scientificname = nodo.GetProperty("organism").GetProperty("scientificname").GetString(),
                TaxId = nodo.GetProperty("organism").GetProperty("taxid").GetInt16(),
            });
        }
    }
}
