namespace Application
{
    public interface IServiceFolding
    {
        public Task<string> GetRanks(string jobId); //info de alineamiento
        public Task<byte[]> GetEstructures(string pdbId, string jobId, string rank);
        public Task<string> InitFoldingJob(string aminoacidSequence); 
        public Task<string> GetFoldingStatus(string jobId); //pending, running, failed, and completed
    }
}
