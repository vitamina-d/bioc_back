using Application.DTO;

namespace Application
{
    public interface IServiceFolding
    {
        public Task<string> GetRanks(string jobId); //info de alineamiento
        public Task<byte[]> GetEstructures(string pdbId, string jobId, string rank);
        public Task<string> InitFoldingJob(string nucleotides, int frame); //-1, -2, -3, 1, 2, 3
        public Task<string> GetFoldingStatus(string jobId); //pending, running, failed, and completed
    }
}
