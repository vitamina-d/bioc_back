﻿using Application;
using Application.DTO;
using Application.DTO.Python;
using Microsoft.AspNetCore.Mvc;
using Presentation.Utils;

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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AlignProtein([FromBody] BodyAlignPdbDto body)
        {
            var response = await _pythonService.AlignPdb(body.PredictionPdb, body.ReferencePdb);
            return ResponseSwitch.StatusCodes(response);
        }
        [HttpPost("complement")]
        [ProducesResponseType(typeof(ResponseDto<SequenceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
        public async Task<IActionResult> GetComplement([FromBody] BodyReverseComplementDto body)
        {
                var response = await _pythonService.ReverseComplement(body.Sequence, body.Reverse, body.Complement);
                return ResponseSwitch.StatusCodes(response);

        }
        [HttpPost("translate")]
        [ProducesResponseType(typeof(ResponseDto<SequenceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTranslate([FromBody] BodyTranslateDto body)
        {
            var response = await _pythonService.Translate(body.Sequence, body.Frame);
            return ResponseSwitch.StatusCodes(response);
        }
    }
}
