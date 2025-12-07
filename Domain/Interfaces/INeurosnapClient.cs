namespace Domain.Interfaces
{
    public interface INeurosnapClient
    {
        public Task<string> InitJob(string aminoacid, string apiKey);
        public Task<string> GetJobStatus(string jobId, string apiKey);
        public Task<string> GetJobs(string apiKey);
        public Task<byte[]> GetPrediction(string jobId, string rank, string apiKey);
        public Task<string> DownloadpLDDT(string jobId, string rank, string apiKey); 
        public Task<string> GetRanks(string jobId, string apiKey);
        public Task<string> GetJob(string jobId, string apiKey);
    }
}
