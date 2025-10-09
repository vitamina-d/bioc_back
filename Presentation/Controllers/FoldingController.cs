using Application;
using Application.DTO.Folding;
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
        
        [HttpPost("initJob")]
        public async Task<IActionResult> InitJob([FromBody] BodyInitFoldDto body)
        {
            var result = await _serviceFolding.InitFoldingJob(body.Sequence, body.Frame);
            return Ok(result); 
        }
        [HttpGet("status/{jobId}")]
        public async Task<IActionResult> GetFoldingStatus(string jobId)
        {
            var status = await _serviceFolding.GetFoldingStatus(jobId);
            return Ok(new { JobId = jobId, Status = status });
        }
        
        [HttpGet("job/{jobId}/ranks")] //lista de ranks, uncertainly.json prot1_rank_x.json del 1 al 5
        public async Task<IActionResult> GetRanks(string jobId)
        {
            var res = await _serviceFolding.GetRanks(jobId);
            return Ok(res);
        }

        [HttpGet("/job/{jobId}/rank_{rank}/structure")] //pdb alineado rank_X
        public async Task<IActionResult> GetEstructures(string pdbId = "4quv", string jobId = "68e17d82e986d44f8b7e9e1b", string rank = "3")
        {
            var alignedFile = await _serviceFolding.GetEstructures(pdbId, jobId, rank);
            return File(alignedFile, "chemical/x-pdb", $"aligned_{pdbId}_{rank}.pdb");
        }
    }
}
