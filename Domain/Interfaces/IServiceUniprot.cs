using Domain.DTO;

namespace Domain.Interfaces
{
    public interface IServiceUniprot
    {
        public Task<ResponseDto<byte[]?>> GetEstructure(string uniprotId);
    }
}
