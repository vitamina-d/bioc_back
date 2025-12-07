using Domain.DTO;
using Domain.DTO.Blast;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Utils;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlastController(IServiceBlast blastService) : ControllerBase
    {
        private readonly IServiceBlast _blastService = blastService;

        [HttpPost("blastx")]
        [ProducesResponseType(typeof(ResponseDto<Report?>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BlastX([FromBody] BodyBlastxDto body)
        {
            var response = await _blastService.Connect(body.Sequence);
            return ResponseSwitch.StatusCodes(response);
        }
    }
}
