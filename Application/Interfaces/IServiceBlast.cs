using Application.DTO;
using Application.DTO.Blast;

namespace Application
{
    public interface IServiceBlast
    {
        public Task<ResponseDto<Report?>> Connect(string sequence);

    }
}
