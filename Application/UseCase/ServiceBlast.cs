using Application.DTO;
using Application.DTO.Blast;
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
        public async Task<ResponseDto<DataBlastxDto?>> Connect(string sequence)
        {
            var res = await _blastClient.BlastX(sequence);
            var json = JsonSerializer.Deserialize<ResponseDto<DataBlastxDto?>>(res);
            return json;
        }
    }
}
