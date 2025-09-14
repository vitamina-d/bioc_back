using Application;
using Application.DTO;
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
        [HttpGet("msg")]
        [ProducesResponseType(typeof(EchoResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMessage([FromQuery] string msg)
        {
            var res = await _blastService.GetMessage(msg);
            return Ok(res);
        }
        [HttpGet("blastx")]
        public IActionResult BlastX(string sequence)
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
