using Application.DTO;

namespace Application
{
    public interface IServiceFolding
    {
        public Task<string> GetEstructures(string jobId, string pdbId);
        public Task<string> InitFoldingJob(string nucleotides, int frame); //-1, -2, -3, 1, 2, 3
        public Task<string> GetFoldingStatus(string jobId); //pending, running, failed, and completed
    }
}
