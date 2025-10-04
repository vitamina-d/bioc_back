using Application.DTO;

namespace Application
{
    public interface IServiceFolding
    {
        public Task<string> GetEstructures(string jobId, string pdbId);
        public Task<string> InitFoldingJob(string nucleotides, string frame);
        public Task<string> GetFoldingStatus(string jobId); //pending, running, failed, and completed
    }
}
