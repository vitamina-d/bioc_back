using Application;
using Application.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoldController : ControllerBase
    {
        private readonly IServiceFold _foldService;

        public FoldController(IServiceFold foldService)
        {
            _foldService = foldService;
        }
        
        [HttpPost("fold")]
        [ProducesResponseType(typeof(DataPdbDto[]), StatusCodes.Status200OK)]
        public IActionResult GetEstructures([FromBody] BodyFoldDto body)
        {
            var res = _foldService.GetEstructures(body);
            return Ok(res);
        }
    }
}
