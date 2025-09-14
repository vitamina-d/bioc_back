using Application.DTO;

namespace Application
{
    public interface IServiceBlast
    {
        public Task<EchoResponseDto> GetMessage(string msg);

        public Task<string> Connect(string sequence);

    }
}
