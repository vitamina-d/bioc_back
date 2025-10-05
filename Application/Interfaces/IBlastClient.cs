namespace Application
{
    public interface IBlastClient
    {
        public Task<string> BlastX(string sequence);
    }
}
