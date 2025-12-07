namespace Domain.Interfaces
{
    public interface IBlastClient
    {
        public Task<string> BlastX(string sequence);
    }
}
