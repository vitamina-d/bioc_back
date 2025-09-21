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
        [ProducesResponseType(typeof(ResponsePlumberDto<Report?>), StatusCodes.Status200OK)]
        public async Task<IActionResult> BlastX([FromBody] BodyBlastxDto body)
        {
            var res = await _blastService.Connect(body.Sequence);
            return Ok(new ResponsePlumberDto<Report?>
            {
                Code = res.Code,
                Message = res.Message,
                DateTime = res.DateTime,
                Time = res.Time,
                Data = res.Data?.BlastOutput2[0].Report
            });
        }
        [HttpPost("blastp")]
        public async Task<IActionResult> BlastP([FromBody] string sequence)
        {
            var res = await _blastService.Connect(sequence);
            return Ok(res);
        }
    }
}
