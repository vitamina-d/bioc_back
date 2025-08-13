using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Xml.Linq;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenomeController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public GenomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //primer endpoint: me trae el mensaje
        [HttpGet("msg")]
        public async Task<IActionResult> GetMessage([FromQuery] string msg)
        {
            // localhost:8000
            // otro contenedor -> host.docker.internal:8000

            var url = $"http://host.docker.internal:8000/echo?msj={Uri.EscapeDataString(msg)}";

            // Realizar la solicitud GET a la API Plumber
            var response = await _httpClient.GetStringAsync(url);
            var json = JsonSerializer.Deserialize<object>(response); //ya no devuelve lista
            return Ok(json);
        }

        [HttpGet("seq")]
        public async Task<IActionResult> GetBSGenomeSequence([FromQuery] string chrom = "chr11", [FromQuery] int start = 100000, [FromQuery] int end = 100100)
        {
            var url = $"http://host.docker.internal:8000/bsgenome?chrom={Uri.EscapeDataString(chrom)}&start={start}&end={end}";

            var response = await _httpClient.GetStringAsync(url);

            return Content(response, "application/json");
        }

        [HttpGet("ensembl")]
        public async Task<IActionResult> GetSequence([FromQuery] string chrom = "11", [FromQuery] int start = 100000, [FromQuery] int end = 100100)
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
