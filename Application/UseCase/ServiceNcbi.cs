using Domain.DTO;
using Domain.DTO.Public;
using Domain.Interfaces;
using System.Text.Json;

namespace Application.UseCase
{
    public class ServiceNcbi(IPublicApiClient publicApiClient) : IServiceNcbi
    {
        private readonly IPublicApiClient _publicApiClient = publicApiClient;

        public async Task<ResponseDto<ResponseNcbiDto?>> GetSummaryFromNcbi(string entrez, string type)
        {
            var response = await _publicApiClient.GetNcbiResponse(entrez, type);
            var json = JsonDocument.Parse(response);
            var nodo = json.RootElement.GetProperty("result").GetProperty(entrez);

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
