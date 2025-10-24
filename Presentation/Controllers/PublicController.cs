using Application;
using Application.DTO;
using Application.DTO.Public;
using Microsoft.AspNetCore.Mvc;
using Presentation.Utils;

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
        [ProducesResponseType(typeof(ResponseDto<ResponseNcbiDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSummary([FromQuery] string entrez)
        {
            string type = "gene";
            var summary = await _servicePublicApi.GetSummaryFromNcbi(entrez, type);
            return ResponseSwitch.StatusCodes(summary);

        }
    }
}
