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

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary([FromQuery] string entrez = "1717")
        {
            string type = "gene";
            var summary = await _servicePublicApi.GetSummaryFromNcbi(entrez, type);
            return Ok(summary);
        
        }
    }
}
