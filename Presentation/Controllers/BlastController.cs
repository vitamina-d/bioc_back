using Application;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlastController : ControllerBase
    {
        private readonly IDockerService _dockerService;
        //https://github.com/testcontainers/Docker.DotNet/

        public BlastController(IDockerService dockerService)
        {
            _dockerService = dockerService;
        }
        [HttpGet("blastx")]
        public IActionResult BlastX()
        {
            var res = _dockerService.Connect();
            return Ok(res);
        }
    }
}
