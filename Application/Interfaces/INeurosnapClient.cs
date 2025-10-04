namespace Application
{
    public interface INeurosnapClient
    {
        public Task<string> InitJob(string aminoAcidSequence);
        public Task<string> GetJobStatus(string jobId);
        public Task<string> GetPrediction(string jobId);

    }
}
