using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public PublicController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("ensembl")]
        public async Task<IActionResult> GetSequenceByRange([FromQuery] string chrom = "chr11", [FromQuery] int start = 100000, [FromQuery] int end = 100100)
        {
            string url = $"https://rest.ensembl.org/sequence/region/human/{chrom}:{start}..{end}?content-type=application/json";
            var response = await _httpClient.GetStringAsync(url);

            return Ok(response);
        }
        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary([FromQuery] string entrez = "1717", string type = "gene")
        {
            string url = $"https://eutils.ncbi.nlm.nih.gov/entrez/eutils/esummary.fcgi?db={type}&id={entrez}&retmode=json";
            
            var response = await _httpClient.GetStringAsync(url);
            // Deserializar
            var json = JsonDocument.Parse(response);

            // nodo del ID 1717
            var nodo = json.RootElement.GetProperty("result").GetProperty(entrez);

            return Ok(new
            {
                EntrezId = entrez,
                Name = nodo.GetProperty("name").GetString(),
                MapLocation = nodo.GetProperty("maplocation").GetString(),
                Description = nodo.GetProperty("description").GetString(),
                Summary = nodo.GetProperty("summary").GetString()
            });
        }
    }
}
