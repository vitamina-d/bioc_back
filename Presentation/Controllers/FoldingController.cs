using Application;
using Application.DTO;
using Application.DTO.Folding;
using Microsoft.AspNetCore.Mvc;
using Presentation.Utils;

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
        
        [HttpPost("init")]
        [ProducesResponseType(typeof(ResponseDto<string?>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InitJob([FromBody] BodyInitFoldDto body)
        {
            var response = await _serviceFolding.InitFoldingJob(body.Aminoacid);
            return ResponseSwitch.StatusCodes(response);
        }
        [HttpGet("status/{jobId}")]
        [ProducesResponseType(typeof(ResponseDto<DataStatusDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
        public async Task<IActionResult> GetFoldingStatus(string jobId)
        {
            var response = await _serviceFolding.GetFoldingStatus(jobId);
            return ResponseSwitch.StatusCodes(response);
        }

        [HttpGet("job/{jobId}/ranks")] //lista de ranks, uncertainly.json prot1_rank_x.json del 1 al 5
        [ProducesResponseType(typeof(ResponseDto<DataRanksDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRanks(string jobId)
        {
            var response = await _serviceFolding.GetRanks(jobId);
            return ResponseSwitch.StatusCodes(response);
        }

        [HttpGet("job/{jobId}/rank_{rank}/align/{pdbId}")] //pdb alineado rank_X
        [ProducesResponseType(typeof(File), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEstructures(string pdbId, string jobId, string rank)
        {
            var alignedBytes = await _serviceFolding.GetEstructures(pdbId, jobId, rank);
            //\nATOM     14  N ??
            if (alignedBytes.Code == 200)
            {
                return File(alignedBytes.Data, "chemical/x-pdb", $"{jobId}_rank{rank}.pdb");
            }
            return ResponseSwitch.StatusCodes(alignedBytes);
        }
    }
}
