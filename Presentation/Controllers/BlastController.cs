using Application;
using Application.DTO;
using Application.DTO.Blast;
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
        [HttpPost("blastx")]
        [ProducesResponseType(typeof(ResponseDto<Report?>), StatusCodes.Status200OK)]
        public async Task<IActionResult> BlastX([FromBody] BodyBlastxDto body)
        {
            var res = await _blastService.Connect(body.Sequence);
            return Ok(new ResponseDto<Report?>
            {
                Code = res.Code,
                Message = res.Message,
                Data = res.Data?.BlastOutput2[0].Report
            });
        }
    }
}
