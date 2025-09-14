namespace Application
{
    public interface IBlastClient
    {
        public Task<string> BlastX(string sequence);
        public Task<string> BlastP(string sequence);
        public Task<string> GetEcho(string msg);

    }
}
