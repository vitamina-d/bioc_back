using Application;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlastController : ControllerBase
    {
        private readonly IServiceBlast _blastService;
        //https://github.com/testcontainers/Docker.DotNet/

        public BlastController(IServiceBlast blastService)
        {
            _blastService = blastService;
        }
        [HttpPost("blastx")]
        public IActionResult BlastX([FromBody] string sequence)
        {
            var res = _blastService.Connect(sequence);
            return Ok(res);
        }
        [HttpPost("blastp")]
        public IActionResult BlastP([FromBody] string sequence)
        {
            var res = _blastService.Connect(sequence);
            return Ok(res);
        }
    }
}
