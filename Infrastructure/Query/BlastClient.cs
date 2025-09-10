using Docker.DotNet;
using Docker.DotNet.Models;

namespace Application
{
    public class BlastClient : IBlastClient
    {
        private readonly DockerClient _client;

        public BlastClient()
        {
            _client = new DockerClientConfiguration(
                new Uri("npipe://./pipe/docker_engine"))
                    .CreateClient();
        }

        public async Task<string> Connect()
        {
            var parameters = new CreateContainerParameters
            {
                Image = "fedora/memcached",
                HostConfig = new HostConfig
                {
                    DNS = new[] { "8.8.8.8", "8.8.4.4" }
                }
            };

            //await _client.Containers.CreateContainerAsync(parameters);
            var containers = await _client.Containers.ListContainersAsync(new ContainersListParameters { All = true });
            return containers.ToString();

        }

    }
}
