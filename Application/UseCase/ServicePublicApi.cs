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
            var code = 0;
            var message = string.Empty;

            try
            {
                var response = await _publicApiClient.GetNcbiResponse(entrez, type);
                var json = JsonDocument.Parse(response);
                var nodo = json.RootElement.GetProperty("result").GetProperty(entrez);

                //llegan en minuscula
                return new ResponseDto<ResponseNcbiDto?>
                {
                    Code = 200,
                    Message = $"Ok.",
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
            catch (TimeoutException ex)
            {
                code = 504;
                message = $"Timeout: {ex.Message}";
            }
            catch (HttpRequestException ex)
            {
                code = 502;
                message = $"Error HTTP: {ex.Message}";
            }
            catch (Exception ex)
            {
                code = 500;
                message = $"Error de servicio: {ex.Message}";
            }
            return new ResponseDto<ResponseNcbiDto?>
            {
                Code = code,
                Message = message,
            };
        }
    }
}
