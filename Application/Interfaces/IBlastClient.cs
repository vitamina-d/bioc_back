namespace Application
{
    public interface IBlastClient
    {
        public Task<string> Connect();

    }
}
