using Docker.DotNet;
using Docker.DotNet.Models;

namespace Application
{
    public class BlastClient : IBlastClient
    {
        private readonly DockerClient _client;

        public BlastClient()
        {
            _client = new DockerClientConfiguration().CreateClient();

        }

        public async Task<string> Connect()
        {
            var res = "";
            try
            {
                IList<ContainerListResponse> containers = await _client.Containers.ListContainersAsync(
                    new ContainersListParameters
                    {
                        Limit = 10,
                    });
            } 
            catch (Exception e)
            {
                res = $"catch: {e}";
                
            }
                        
            return res;

        }

    }
}
