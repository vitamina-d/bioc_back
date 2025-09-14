using Application.DTO;

namespace Application
{
    public interface IServiceBlast
    {
        public Task<EchoResponseDto> GetMessage(string msg);

        public Task<ResponsePlumberDto<DataBlastxDto?>> Connect(string sequence);

    }
}
