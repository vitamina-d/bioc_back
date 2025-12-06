using Domain.DTO;
using Domain.DTO.Blast;
using Domain.DTO.Public;

namespace Domain
{
    public interface IServiceNcbi
    {
        public Task<Domain.DTO.ResponseDto<ResponseNcbiDto?>> GetSummaryFromNcbi(string entrez, string type);
        public Task<ResponseDto<string?>> InitJob(string nucleotides);
        public Task<ResponseDto<string?>> GetRidStatus(string rid);
        public Task<ResponseDto<DataBlastXml?>> GetResultRid(string rid);
    }
}
