namespace Application
{
    public interface INeurosnapClient
    {
        public Task<string> InitJob(string aminoAcidSequence);
        public Task<string> GetJobStatus(string jobId);
        public Task<byte[]> GetPrediction(string jobId, string rank);
        public Task<string> GetRanks(string jobId);

    }
}
