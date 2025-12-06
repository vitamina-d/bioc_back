namespace Domain
{
    public interface INcbiClient
    {
        public Task<string> InitJob(string nucleotides);
        public Task<string> GetRidStatus(string rid);
        public Task<string> GetResultRid(string rid);
    }
}
