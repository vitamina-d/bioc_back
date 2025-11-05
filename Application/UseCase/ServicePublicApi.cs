using Application.DTO;
using Application.DTO.Public;
using Application.DTO.Python;
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
        public async Task<ResponseDto<ResponseNcbiDto?>> GetSummaryFromNcbi(string entrez, string type)
        {
            int code;
            var message = string.Empty;

            var response = await _publicApiClient.GetNcbiResponse(entrez, type);
            var json = JsonDocument.Parse(response);
            var nodo = json.RootElement.GetProperty("result").GetProperty(entrez);

            //llegan en minuscula
            return new ResponseDto<ResponseNcbiDto?>
            {
                Code = 200,
                Message = "Ok.",
                Data = new ResponseNcbiDto
                {
                    Name = nodo.GetProperty("name").GetString(),
                    Description = nodo.GetProperty("description").GetString(),
                    Summary = nodo.GetProperty("summary").GetString(),
                    Scientificname = nodo.GetProperty("organism").GetProperty("scientificname").GetString(),
                    TaxId = nodo.GetProperty("organism").GetProperty("taxid").GetInt32(),
                },
            };
        }
    }
}
