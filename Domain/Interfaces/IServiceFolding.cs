using Domain.DTO;
using Domain.DTO.Folding;

namespace Domain.Interfaces
{
    public interface IServiceFolding
    {
        public Task<ResponseDto<Dictionary<string, double>?>> GetRanks(string jobId, string apiKey);
        public Task<ResponseDto<string?>> GetJob(string jobId, string apiKey);
        public Task<ResponseDto<byte[]?>> GetPrediction(string accession, string jobId, string rank, string apiKey);
        public Task<ResponseDto<byte[]?>> GetReference(string accession); 
        public Task<ResponseDto<PLDDTRcsbDto?>> GetModelPLDDT(string accession);
        public Task<ResponseDto<PLDDTNeurosnapDto?>> GetPredictionPLDDT(string jobId, string rank, string apiKey);
        public Task<ResponseDto<string?>> InitFoldingJob(string aminoacid, string apiKey); 
        public Task<ResponseDto<string?>> GetFoldingStatus(string jobId, string apiKey); 
    }
}
