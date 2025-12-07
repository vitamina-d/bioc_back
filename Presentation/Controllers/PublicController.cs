using Domain.DTO;
using Domain.DTO.Public;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Utils;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController(IServiceNcbi servicePublicApi, IServiceUniprot serviceUniprot) : ControllerBase
    {
        private readonly IServiceNcbi _servicePublicApi = servicePublicApi;
        private readonly IServiceUniprot _serviceUniprot = serviceUniprot;

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
        
        [HttpGet("model/{uniprotId}")] 
        [ProducesResponseType(typeof(File), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEstructure([FromRoute] string uniprotId)
        {
            var bytes = await _serviceUniprot.GetEstructure(uniprotId);
            if (bytes.Code == 200)
            {
                return File(bytes.Data, "chemical/x-pdb", $"{uniprotId}.pdb");
            }
            return ResponseSwitch.StatusCodes(bytes);
        }
    }
}
