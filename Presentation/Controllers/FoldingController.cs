using Application;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoldingController : ControllerBase
    {
        private readonly IServiceFolding _serviceFolding;

        public FoldingController(IServiceFolding serviceFolding)
        {
            _serviceFolding = serviceFolding;
        }
        
        [HttpGet("estructures")]
        public async Task<IActionResult> GetEstructures(string jobId, string pdbId)
        {
            var res = await _serviceFolding.GetEstructures(jobId, pdbId);
            return Ok(res);
        }
        [HttpPost("initJob")]
        public async Task<IActionResult> PostJob([FromBody] BodyInitFoldDto body)
        {
            var result = await _serviceFolding.InitFoldingJob(body.Sequence, body.Frame);
            return Ok(result); // { refPdb, predAlignedPdb, rmsd }
        }

        [HttpGet("status/{jobId}")]
        public async Task<IActionResult> GetFoldingStatus(string jobId)
        {
            var status = await _serviceFolding.GetFoldingStatus(jobId);
            return Ok(new { JobId = jobId, Status = status });
        }
    }
}
