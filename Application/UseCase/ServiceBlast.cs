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
        public async Task<ResponseDto<Report?>> Connect(string sequence)
        {
            try
            {
                var res = await _blastClient.BlastX(sequence);
                var json = JsonSerializer.Deserialize<ResponseDto<DataBlastxDto?>>(res);

                return new ResponseDto<Report?>
                {
                    Code = json.Code,
                    Message = json.Message,
                    Data = json.Data?.BlastOutput2[0].Report 
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<Report?>
                {
                    Code = 500,
                    Message = $"Error: {ex.Message}",
                    Data = null
                };
            }
        }
    }
}
