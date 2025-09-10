namespace Application
{
    public interface IDockerService
    {
        public Task<string> Connect();

    }
}
