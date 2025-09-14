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
        [HttpPost("blastx")]
        [ProducesResponseType(typeof(ResponsePlumberDto<DataBlastxDto?>), StatusCodes.Status200OK)]
        public async Task<IActionResult> BlastX([FromBody] string sequence)
        {
            var res = await _blastService.Connect(sequence);
            return Ok(res);
        }
        [HttpPost("blastp")]
        public async Task<IActionResult> BlastP([FromBody] string sequence)
        {
            var res = await _blastService.Connect(sequence);
            return Ok(res);
        }
    }
}
