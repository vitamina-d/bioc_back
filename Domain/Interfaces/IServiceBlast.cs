using Domain.DTO;
using Domain.DTO.Blast;

namespace Domain.Interfaces
{
    public interface IServiceBlast
    {
        public Task<ResponseDto<Report?>> Connect(string sequence);
    }
}
