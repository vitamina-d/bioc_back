using Domain.DTO;
using Domain.DTO.Folding;

namespace Domain
{
    public interface IServiceFolding
    {
        public Task<ResponseDto<Dictionary<string, double>?>> GetRanks(string jobId, string apiKey); //info de alineamiento
        public Task<ResponseDto<string?>> GetJob(string jobId, string apiKey); //info de alineamiento
        public Task<ResponseDto<byte[]?>> GetPrediction(string accession, string jobId, string rank, string apiKey);
        public Task<ResponseDto<byte[]?>> GetReference(string accession); 
        public Task<ResponseDto<pLDDTRcsbDto?>> GetModelPLDDT(string accession);
        public Task<ResponseDto<pLDDTNeurosnapDto?>> GetPredictionPLDDT(string jobId, string rank, string apiKey);

        public Task<ResponseDto<string?>> InitFoldingJob(string aminoacid, string apiKey); 
        public Task<ResponseDto<string?>> GetFoldingStatus(string jobId, string apiKey); //pending, running, failed, and completed
    }
}
