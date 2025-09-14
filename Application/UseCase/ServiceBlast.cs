using Application.DTO;
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

        public Task<string> Connect(string sequence)
        {
            var res = _blastClient.BlastX(sequence);
            return res;
        }

        public async Task<EchoResponseDto> GetMessage(string msg)
        {
            var res = await _blastClient.GetEcho(msg);
            var json = JsonSerializer.Deserialize<EchoResponseDto>(res);
            return json;
        }
    }
}
