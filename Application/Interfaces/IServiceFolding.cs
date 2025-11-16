using Application.DTO;

namespace Application
{
    public interface IServiceFolding
    {
        public Task<ResponseDto<Dictionary<string, double>?>> GetRanks(string jobId); //info de alineamiento
        public Task<ResponseDto<string?>> GetJob(string jobId); //info de alineamiento
        public Task<ResponseDto<byte[]?>> GetPrediction(string pdbId, string jobId, string rank);
        public Task<ResponseDto<byte[]?>> GetModelReference(string accession); 
        public Task<ResponseDto<string?>> GetModelPLDDT(string accession);
        public Task<ResponseDto<string?>> InitFoldingJob(string aminoacidSequence); 
        public Task<ResponseDto<string?>> GetFoldingStatus(string jobId); //pending, running, failed, and completed
    }
}
