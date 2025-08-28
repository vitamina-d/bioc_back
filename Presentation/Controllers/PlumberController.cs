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

        /*[HttpGet("msg")]
        public async Task<IActionResult> GetMessage([FromQuery] string msg = "msg")
        {
            var res = await _servicePlumberApi.GetMessage(msg);
            return Ok(res);
        }*/

        [HttpPost("align")]
        public async Task<IActionResult> GetAlign([FromBody] BodyAlignDto bodyDto)
        {
            var res = await _servicePlumberApi.GetAlignment(bodyDto);
            return Ok(res);
        }
        [HttpPost("complement")]
        public async Task<IActionResult> GetComplement([FromBody] BodyComplementDto bodyDto)
        {
            var res = await _servicePlumberApi.GetComplement(bodyDto);
            return Ok(res);
        }
        [HttpGet("detail")]
        public async Task<IActionResult> GetDetail([FromQuery] string value, [FromQuery] bool full) //entrez, alias o symbol
        {
            var res = await _servicePlumberApi.GetDetail(value, full);
            return Ok(res);
        }
        [HttpPost("percent")]
        public async Task<IActionResult> GetPercent([FromBody] string sequence = "ATCG")
        {
            var response = await _servicePlumberApi.GetPercent(sequence); 
            return Ok(response);
        }

        [HttpGet("sequence")]
        public async Task<IActionResult> GetSequence([FromQuery] string value = "DHCR7", [FromQuery] bool complete = true)
        {
            var response = await _servicePlumberApi.GetSequence(value, complete);
            return Ok(response);
        }
        
        [HttpGet("sequence_by_range")]
        public async Task<IActionResult> GetSequenceByRange([FromQuery] string chrom = "chr11", [FromQuery] int start = 71428193, [FromQuery] int end = 71452868)
        {
            var res = await _servicePlumberApi.GetSequence(chrom, start, end);
            return Ok(res);
        }
        [HttpGet("table")]
        public async Task<IActionResult> GetTable()
        {
            var res = await _servicePlumberApi.GetTable();
            return Ok(res);
        }
        [HttpGet("genename")]
        public async Task<IActionResult> GetGenename()
        {
            var res = await _servicePlumberApi.GetGenenames();
            return Ok(res);
        }
    }
}
