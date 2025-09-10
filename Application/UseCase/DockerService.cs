namespace Application
{
    public class DockerService : IDockerService
    {
        private readonly IBlastClient _blastClient;
        public DockerService(IBlastClient blastClient)
        {
            _blastClient = blastClient;

        }

        public Task<string> Connect()
        {
            var res = _blastClient.Connect();
            return res;
        }

    }
}
