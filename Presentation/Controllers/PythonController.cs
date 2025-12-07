using Domain.DTO;
using Domain.DTO.Python;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Utils;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PythonController(IServicePython pythonService) : ControllerBase
    {
        private readonly IServicePython _pythonService = pythonService;

        [HttpPost("align")]
        [ProducesResponseType(typeof(ResponseDto<BodyAlignPdbDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AlignProtein([FromBody] BodyAlignPdbDto body)
        {
            var response = await _pythonService.AlignPdb(body.PredictionPdb, body.ReferencePdb);
            return ResponseSwitch.StatusCodes(response);
        }
        [HttpPost("compare/{reference_id}")]
        [Consumes("multipart/form-data")]
        //[Consumes("chemical/x-pdb")]
        [ProducesResponseType(typeof(File), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CompareProtein([FromRoute] string reference_id, [FromForm] IFormFile pdb_file)
        {
            if (pdb_file == null || pdb_file.Length == 0)
                return BadRequest("Archivo PDB vacío o nulo.");

            using var ms = new MemoryStream();
            await pdb_file.CopyToAsync(ms);
            var bytes = ms.ToArray(); 

            var response = await _pythonService.ComparePdb(bytes, reference_id);
            if (response.Code == 200)
            {
                return File(response.Data, "chemical/x-pdb", $"{pdb_file.Name}_align.pdb");
            }
            return ResponseSwitch.StatusCodes(response);
        }

        [HttpPost("complement")]
        [ProducesResponseType(typeof(ResponseDto<SequenceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
        public async Task<IActionResult> GetComplement([FromBody] BodyReverseComplementDto body)
        {
                var response = await _pythonService.ReverseComplement(body.Sequence, body.Reverse, body.Complement);
                return ResponseSwitch.StatusCodes(response);

        }
        [HttpPost("translate")]
        [ProducesResponseType(typeof(ResponseDto<SequenceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTranslate([FromBody] BodyTranslateDto body)
        {
            var response = await _pythonService.Translate(body.Sequence, body.Frame);
            return ResponseSwitch.StatusCodes(response);
        }

    }
}
