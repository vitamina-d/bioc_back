using Domain.DTO;
using Domain.DTO.Public;

namespace Domain.Interfaces
{
    public interface IServiceNcbi
    {
        public Task<ResponseDto<ResponseNcbiDto?>> GetSummaryFromNcbi(string entrez, string type);
    }
}
