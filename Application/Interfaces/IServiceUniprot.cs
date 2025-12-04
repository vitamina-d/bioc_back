using Application.DTO;

namespace Application
{
    public interface IServiceUniprot
    {
        public Task<ResponseDto<byte[]?>> GetEstructure(string uniprotId);

    }
}
