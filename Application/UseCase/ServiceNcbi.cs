using Domain;
using Domain.DTO;
using Domain.DTO.Blast;
using Domain.DTO.Public;
using System.Text.Json;
using System.Xml.Serialization;

namespace Application.UseCase
{
    public class ServiceNcbi(IPublicApiClient publicApiClient, INcbiClient ncbiClient) : IServiceNcbi
    {
        private readonly IPublicApiClient _publicApiClient = publicApiClient;
        private readonly INcbiClient _ncbiClient = ncbiClient;

        public async Task<ResponseDto<string?>> InitJob(string nucleotides)
        {
            var rid =  await _ncbiClient.InitJob(nucleotides);
            return new ResponseDto<string?>
            {
                Code = 200,
                Message = "Ok.",
                Data = rid
            }; 
        }
        public async Task<ResponseDto<string?>> GetRidStatus(string rid)
        {
            var response = await _ncbiClient.GetRidStatus(rid);
            return new ResponseDto<string?>
            {
                Code = 200,
                Message = "Ok.",
                Data = response
            };
        }
        public async Task<ResponseDto<DataBlastXml?>> GetResultRid(string rid)
        {
            var result = await _ncbiClient.GetResultRid(rid);
            var serializer = new XmlSerializer(typeof(DataBlastXml));
            using var reader = new StringReader(result);
            var data = (DataBlastXml?)serializer.Deserialize(reader);
            return new ResponseDto<DataBlastXml?>
            {
                Code = 200,
                Message = "Ok.",
                Data = data 
            };
        }
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
