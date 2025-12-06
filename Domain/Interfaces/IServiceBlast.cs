using Domain.DTO;
using Domain.DTO.Blast;

namespace Domain
{
    public interface IServiceBlast
    {
        public Task<ResponseDto<Report?>> Connect(string sequence);

    }
}
