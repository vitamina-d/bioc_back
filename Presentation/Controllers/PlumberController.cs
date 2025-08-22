using Application;
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
        public async Task<IActionResult> GetMessage([FromQuery] string msg = "msg")
        {
            var res = await _servicePlumberApi.GetMessage(msg);
            return Ok(res);
        }

        [HttpGet("align")]
        public async Task<IActionResult> GetAlign([FromQuery] string pattern = "ATCG", [FromQuery] string subject = "ATCG", [FromQuery] bool global = true)
        {
            var res = await _servicePlumberApi.GetAlignment(pattern, subject, global);
            return Ok(res);
        }

        [HttpGet("detail")]
        public async Task<IActionResult> GetDetail([FromQuery] string value = "DHCR7") //entrez, alias o symbol
        {
            var res = await _servicePlumberApi.GetDetail(value);
            return Ok(res);
        }
        [HttpGet("percent")]
        public async Task<IActionResult> GetPercent([FromQuery] string sequence = "ATCG")
        {
            var response = await _servicePlumberApi.GetPercent(sequence); 
            return Ok(response);
        }

        [HttpGet("sequence_by_symbol")]
        public async Task<IActionResult> GetSequenceBySymbol([FromQuery] string gene_symbol = "DHCR7", [FromQuery] bool complete = true)
        {
            var response = await _servicePlumberApi.GetSequence(gene_symbol, complete);
            return Ok(response);
        }

        [HttpGet("sequence_by_range")]
        public async Task<IActionResult> GetSequenceByRange([FromQuery] string chrom = "chr11", [FromQuery] int start = 71428193, [FromQuery] int end = 71452868)
        {
            var res = await _servicePlumberApi.GetSequence(chrom, start, end);
            return Ok(res);
        }
    }
}
