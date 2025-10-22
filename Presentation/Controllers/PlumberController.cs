using Application;
using Application.DTO;
using Application.DTO.Plumber;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("msg")]
        [ProducesResponseType(typeof(EchoResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMessage([FromQuery] string msg)
        {
            var res = await _servicePlumberApi.GetMessage(msg);
            return Ok(res);
        }

        [HttpGet("autocomplete")]
        [ProducesResponseType(typeof(ResponseDto<List<string>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAutoComplete([FromQuery] string input)
        {
            var autocomplete = await _servicePlumberApi.GetAutoComplete(input.ToUpper());
            return Ok(autocomplete);
        }
        [HttpPost("align")]
        [ProducesResponseType(typeof(ResponseDto<DataAlignDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAlign([FromBody] BodyAlignDto body)
        {
            var res = await _servicePlumberApi.GetAlignment(body.Pattern, body.Subject, body.Type, body.GapOpening, body.GapExtension);
            return Ok(res);
        }
        [HttpGet("detail")]
        [ProducesResponseType(typeof(ResponseDto<DataFullDetailDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDetail([FromQuery] string value, [FromQuery] bool full) //entrez, alias o symbol
        {
            if (full)
            {
                var fullDetail = await _servicePlumberApi.GetDetail<DataFullDetailDto>(value.ToUpper(), full);
                return Ok(fullDetail);
            } else
            {
                var detail = await _servicePlumberApi.GetDetail<DataDetailDto>(value.ToUpper(), full);
                return Ok(detail);
            }
        }
        [HttpPost("percent")]
        [ProducesResponseType(typeof(ResponseDto<DataPercentDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPercent([FromBody] string sequence)
        {
            var response = await _servicePlumberApi.GetPercent(sequence); 
            return Ok(response);
        }

        [HttpGet("sequence_by_range")]
        [ProducesResponseType(typeof(ResponseDto<DataSequenceDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSequenceByRange([FromQuery] string chrom, [FromQuery] int start, [FromQuery] int end)
        {
            var res = await _servicePlumberApi.GetSequence(chrom, start, end);
            return Ok(res);
        }

        [HttpGet("sequence")]
        [ProducesResponseType(typeof(ResponseDto<DataSequenceDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSequenceByEntrez([FromQuery] string entrez, [FromQuery] bool complete)
        {
            var response = await _servicePlumberApi.GetSequence(entrez, complete);
            return Ok(response);
        }
        [HttpGet("stats")]
        [ProducesResponseType(typeof(ResponseDto<DataStatsDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStats([FromQuery] string entrez, [FromQuery] bool complete)
        {
            var response = await _servicePlumberApi.GetStats(entrez, complete);
            return Ok(response);
        }

        [HttpGet("entrez/{value}")]
        [ProducesResponseType(typeof(ResponseDto<DataEntrezDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEntrez(string value)
        {
            var entrez = await _servicePlumberApi.GetEntrezByValue(value.ToUpper());
            return Ok(entrez);
        }
    }
}
