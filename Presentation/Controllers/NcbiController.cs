using Domain;
using Domain.DTO;
using Domain.DTO.Blast;
using Microsoft.AspNetCore.Mvc;
using Presentation.Utils;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NcbiController : ControllerBase
    {
        private readonly IServiceNcbi _serviceNcbi;
        public NcbiController(IServiceNcbi serviceNcbi)
        {
            _serviceNcbi = serviceNcbi;
        }

        [HttpPost("init")]
        [ProducesResponseType(typeof(ResponseDto<string?>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InitJob([FromBody] string nucleotides)
        {
            var response = await _serviceNcbi.InitJob(nucleotides);
            return ResponseSwitch.StatusCodes(response);
        }
        [HttpGet("status/{rid}")]
        [ProducesResponseType(typeof(ResponseDto<string?>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
        public async Task<IActionResult> GetStatus([FromRoute] string rid)
        {
            var response = await _serviceNcbi.GetRidStatus(rid);
            return ResponseSwitch.StatusCodes(response);
        }

        [HttpGet("result/{rid}")]
        [ProducesResponseType(typeof(ResponseDto<DataBlastXml?>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetResult([FromRoute] string rid)
        {
            var response = await _serviceNcbi.GetResultRid(rid);
            return ResponseSwitch.StatusCodes(response);
        }
    }
}
