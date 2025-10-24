using Application;
using Application.DTO;
using Application.DTO.Plumber;
using Microsoft.AspNetCore.Mvc;
using Presentation.Utils;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlumberController : ControllerBase
    {
        private readonly IServicePlumberApi _servicePlumberApi;


        public PlumberController(IServicePlumberApi servicePlumberApi)
        {
            _servicePlumberApi = servicePlumberApi;
        }
        [HttpGet("autocomplete")]//ok
        [ProducesResponseType(typeof(ResponseDto<List<string>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
        public async Task<IActionResult> GetAutoComplete([FromQuery] string input)
        {
            var autocomplete = await _servicePlumberApi.GetAutoComplete(input.ToUpper());
            return ResponseSwitch.StatusCodes(autocomplete);
        }
        [HttpPost("align")]
        [ProducesResponseType(typeof(ResponseDto<DataAlignDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
        public async Task<IActionResult> GetAlign([FromBody] BodyAlignDto body)
        {
            var response = await _servicePlumberApi.GetAlignment(body.Pattern, body.Subject, body.Type, body.GapOpening, body.GapExtension);
            return ResponseSwitch.StatusCodes(response);
        }
        [HttpGet("detail")]
        [ProducesResponseType(typeof(ResponseDto<Object>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
        public async Task<IActionResult> GetDetail([FromQuery] string entrez, [FromQuery] bool isFull)
        {
            if (isFull)
            {
                var fullDetail = await _servicePlumberApi.GetFullDetail(entrez);
                return ResponseSwitch.StatusCodes(fullDetail);
            }
            
            var detail = await _servicePlumberApi.GetDetail(entrez);
            return ResponseSwitch.StatusCodes(detail);
        }
        [HttpPost("percent")]
        [ProducesResponseType(typeof(ResponseDto<DataPercentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPercent([FromBody] string sequence)
        {
            var response = await _servicePlumberApi.GetPercent(sequence);
            return ResponseSwitch.StatusCodes(response);
        }

        [HttpGet("sequence_by_range")]
        [ProducesResponseType(typeof(ResponseDto<DataSequenceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
        public async Task<IActionResult> GetSequenceByRange([FromQuery] string chrom, [FromQuery] int start, [FromQuery] int end)
        {
            var response = await _servicePlumberApi.GetSequence(chrom, start, end);
            return ResponseSwitch.StatusCodes(response);
        }

        [HttpGet("sequence")]
        [ProducesResponseType(typeof(ResponseDto<DataSequenceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
        public async Task<IActionResult> GetSequenceByEntrez([FromQuery] string entrez, [FromQuery] bool complete)
        {
            var response = await _servicePlumberApi.GetSequence(entrez, complete);
            return ResponseSwitch.StatusCodes(response);
        }
        [HttpGet("stats")]
        [ProducesResponseType(typeof(ResponseDto<DataStatsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStats([FromQuery] string entrez, [FromQuery] bool complete)
        {
            var response = await _servicePlumberApi.GetStats(entrez, complete);
            return ResponseSwitch.StatusCodes(response);
        }

        [HttpGet("entrez/{value}")]
        [ProducesResponseType(typeof(ResponseDto<DataEntrezDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
        public async Task<IActionResult> GetEntrez(string value)
        {
            var entrez = await _servicePlumberApi.GetEntrezByValue(value.ToUpper());
            return ResponseSwitch.StatusCodes(entrez);
        }
    }
}
