using Application;
using Application.DTO;
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

        [HttpPost("align")]
        [ProducesResponseType(typeof(ResponsePlumberDto<DataAlignDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAlign([FromBody] BodyAlignDto bodyDto)
        {
            var res = await _servicePlumberApi.GetAlignment(bodyDto);
            return Ok(res);
        }
        [HttpPost("complement")]
        [ProducesResponseType(typeof(ResponsePlumberDto<DataComplementDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetComplement([FromBody] BodyComplementDto bodyDto)
        {
            var res = await _servicePlumberApi.GetComplement(bodyDto);
            return Ok(res);
        }
        [HttpGet("detail")]
        [ProducesResponseType(typeof(ResponsePlumberDto<DataFullDetailDto>), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(ResponsePlumberDto<DataPercentDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPercent([FromBody] string sequence)
        {
            var response = await _servicePlumberApi.GetPercent(sequence); 
            return Ok(response);
        }

        [HttpGet("sequence_by_range")]
        [ProducesResponseType(typeof(ResponsePlumberDto<DataSequenceDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSequenceByRange([FromQuery] string chrom, [FromQuery] int start, [FromQuery] int end)
        {
            var res = await _servicePlumberApi.GetSequence(chrom, start, end);
            return Ok(res);
        }

        [HttpGet("sequence")]
        [ProducesResponseType(typeof(ResponsePlumberDto<DataSequenceDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSequence([FromQuery] string entrez, [FromQuery] bool complete)
        {
            var response = await _servicePlumberApi.GetSequence(entrez, complete);
            return Ok(response);
        }
        [HttpGet("stats")]
        [ProducesResponseType(typeof(ResponsePlumberDto<DataStatsDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStats([FromQuery] string entrez, [FromQuery] bool complete)
        {
            var response = await _servicePlumberApi.GetStats(entrez, complete);
            return Ok(response);
        }

        [HttpGet("autocomplete")]
        [ProducesResponseType(typeof(ResponsePlumberDto<List<string>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAutoComplete([FromQuery] string input)
        {
            var autocomplete = await _servicePlumberApi.GetAutoComplete(input.ToUpper());
            return Ok(autocomplete);
        }

        [HttpGet("table")]
        [ProducesResponseType(typeof(ResponsePlumberDto<DataTableDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTable()
        {
            var res = await _servicePlumberApi.GetTable();
            return Ok(res);
        }
        [HttpGet("genename")]
        [ProducesResponseType(typeof(ResponsePlumberDto<DataTableDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGenename()
        {
            var res = await _servicePlumberApi.GetGenenames();
            return Ok(res);
        }
        [HttpGet("entrez/{id}")]
        [ProducesResponseType(typeof(ResponsePlumberDto<DataEntrezDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEntrez(string id)
        {
            var res = await _servicePlumberApi.GetEntrezByValue(id.ToUpper());
            return Ok(res);
        }
    }
}
