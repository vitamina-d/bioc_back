using Application.DTO;
using Application.DTO.Blast;
using Application.DTO.Public;

namespace Application
{
    public interface IServiceNcbi
    {
        public Task<ResponseDto<ResponseNcbiDto?>> GetSummaryFromNcbi(string entrez, string type);
        public Task<ResponseDto<string?>> InitJob(string nucleotides);
        public Task<ResponseDto<string?>> GetRidStatus(string rid);
        public Task<ResponseDto<DataBlastXml?>> GetResultRid(string rid);
    }
}
