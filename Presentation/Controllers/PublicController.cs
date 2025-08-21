using Application;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        private readonly IServicePublicApi _servicePublicApi;

        public PublicController(HttpClient httpClient, IServicePublicApi servicePublicApi)
        {
            _servicePublicApi = servicePublicApi;
        }

        [HttpGet("ensembl")]
        public async Task<IActionResult> GetSequenceByRange([FromQuery] string chrom = "11", [FromQuery] int start = 100000, [FromQuery] int end = 100100)
        {

            var res = await _servicePublicApi.GetSequenceFromEnsembl(chrom, start, end);
            return Ok(res);

        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary([FromQuery] string entrez = "1717", string type = "gene")
        {

            var summary = await _servicePublicApi.GetSummaryFromNcbi(entrez, type);
            return Ok(summary);
        
        }
    }
}
