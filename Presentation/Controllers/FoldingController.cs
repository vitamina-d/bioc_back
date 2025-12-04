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
        public async Task<IActionResult> InitJob([FromQuery] string aminoacid)
        {
            var apiKey = Request.Headers["X-API-KEY"].ToString();
            var response = await _serviceFolding.InitFoldingJob(aminoacid, apiKey);
            return ResponseSwitch.StatusCodes(response);
        }
        [HttpGet("status/{jobId}")]
        [ProducesResponseType(typeof(ResponseDto<DataStatusDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
        public async Task<IActionResult> GetFoldingStatus([FromRoute] string jobId)
        {
            var apiKey = Request.Headers["X-API-KEY"].ToString();
            var response = await _serviceFolding.GetFoldingStatus(jobId, apiKey);
            return ResponseSwitch.StatusCodes(response);
        }

        [HttpGet("job/{jobId}/ranks")] 
        [ProducesResponseType(typeof(ResponseDto<DataRanksDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRanks([FromRoute] string jobId)
        {
            var apiKey = Request.Headers["X-API-KEY"].ToString();
            var response = await _serviceFolding.GetRanks(jobId, apiKey);
            return ResponseSwitch.StatusCodes(response);
        }

        [HttpGet("job/{jobId}/rank_{rank}/align/{accession}")] //pdb alineado rank_X
        [ProducesResponseType(typeof(File), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPrediction([FromRoute] string accession, [FromRoute] string jobId, [FromRoute] string rank)
        {
            var apiKey = Request.Headers["X-API-KEY"].ToString();
            var alignedBytes = await _serviceFolding.GetPrediction(accession, jobId, rank, apiKey);
            if (alignedBytes.Code == 200)
            {
                return File(alignedBytes.Data, "chemical/x-pdb", $"{jobId}_rank{rank}.pdb");
            }
            return ResponseSwitch.StatusCodes(alignedBytes);
        }
        [HttpGet("job/{jobId}/rank_{rank}/pLDDT")] 
        [ProducesResponseType(typeof(ResponseDto<pLDDTNeurosnapDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPredictionPLDDT([FromRoute] string jobId, [FromRoute] string rank)
        {
            var apiKey = Request.Headers["X-API-KEY"].ToString();
            var model = await _serviceFolding.GetPredictionPLDDT(jobId, rank, apiKey);
            return ResponseSwitch.StatusCodes(model);
        }

        [HttpGet("model/{accession}")]
        [ProducesResponseType(typeof(File), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetModelReference([FromRoute] string accession)
        {
            var model = await _serviceFolding.GetReference(accession);
            if (model.Code == 200)
            {
                return File(model.Data, "chemical/x-pdb", $"{accession}.pdb");
            }
            return ResponseSwitch.StatusCodes(model);
        }
        [HttpGet("model/pLDDT/{accession}")]
        [ProducesResponseType(typeof(ResponseDto<pLDDTRcsbDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetModelPLDDT([FromRoute] string accession)
        {
            var model = await _serviceFolding.GetModelPLDDT(accession);
            return ResponseSwitch.StatusCodes(model);
        }

        [HttpGet("job/{jobId}")]
        [ProducesResponseType(typeof(ResponseDto<string?>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetJob([FromRoute] string jobId)
        {
            var apiKey = Request.Headers["X-API-KEY"].ToString();
            var response = await _serviceFolding.GetJob(jobId, apiKey);
            return ResponseSwitch.StatusCodes(response);
        }
    }
}
