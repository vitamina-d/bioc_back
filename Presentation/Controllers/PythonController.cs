using Application;
using Application.DTO;
using Application.DTO.Python;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PythonController : ControllerBase
    {
        private readonly IServicePython _pythonService;

        public PythonController(IServicePython pythonService)
        {
            _pythonService = pythonService;
        }
        [HttpPost("align")]
        [ProducesResponseType(typeof(ResponseDto<BodyAlignPdbDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AlignProtein([FromBody] BodyAlignPdbDto body)
        {
            var res = await _pythonService.AlignPdb(body.PredictionPdb, body.ReferencePdb);
            return Ok(res);
        }
        [HttpPost("complement")]
        [ProducesResponseType(typeof(ResponseDto<SequenceDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetComplement([FromBody] BodyReverseComplementDto body)
        {
            var res = await _pythonService.ReverseComplement(body.Sequence, body.Reverse, body.Complement);
            return Ok(res);
        }
        [HttpPost("translate")]
        [ProducesResponseType(typeof(ResponseDto<SequenceDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetComplement([FromBody] BodyTranslateDto body)
        {
            var res = await _pythonService.Translate(body.Sequence, body.Frame);
            return Ok(res);
        }
    }
}
