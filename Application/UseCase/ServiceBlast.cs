
using Domain.DTO;
using Domain;
using Domain.DTO.Blast;
using System.Text.Json;

namespace Application
{
    public class ServiceBlast : IServiceBlast
    {
        private readonly IBlastClient _blastClient;
        public ServiceBlast(IBlastClient blastClient)
        {
            _blastClient = blastClient;
        }
        public async Task<ResponseDto<Report?>> Connect(string sequence)
        {
            var res = await _blastClient.BlastX(sequence);
            var json = JsonSerializer.Deserialize<ResponseDto<DataBlastxDto?>>(res);

            return new ResponseDto<Report?>
            {
                Code = json.Code,
                Message = json.Message,
                Data = json.Data?.BlastOutput2?.FirstOrDefault()?.Report
            };
        }
    }
}
