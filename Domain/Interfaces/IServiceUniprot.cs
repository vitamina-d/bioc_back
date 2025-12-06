using Domain.DTO;

namespace Domain
{
    public interface IServiceUniprot
    {
        public Task<ResponseDto<byte[]?>> GetEstructure(string uniprotId);

    }
}
