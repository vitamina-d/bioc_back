using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlumberController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _plumberBaseUrl;

        public PlumberController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _plumberBaseUrl = "http://host.docker.internal:8000";
        }

        [HttpGet("msg")]
        public async Task<IActionResult> GetMessage([FromQuery] string msg = "msg")
        {
            var url = $"{_plumberBaseUrl}/echo/?msg={Uri.EscapeDataString(msg)}";
            var response = await _httpClient.GetStringAsync(url); 
            //var json = JsonSerializer.Deserialize<object>(response); //lo agrego en plumber o aca
            return Ok(response);
        }

        [HttpGet("sequence_by_symbol")]
        public async Task<IActionResult> GetSequenceBySymbol([FromQuery] string gene_symbol = "DHCR7", [FromQuery] bool complete = true)
        {
            // seq_by_symbol devuelve la secuencia completa o de exones, dado el symbol de un gen
            //'http://localhost:8787/p/df91a627/seq_by_symbol/?gene_symbol=DHCR7&complete=true'
            var url = $"{_plumberBaseUrl}/seq_by_symbol/?gene_symbol={gene_symbol.ToUpper()}&complete={complete}";
            var response = await _httpClient.GetStringAsync(url);
            return Ok(response);
        }

        [HttpGet("percent")]
        public async Task<IActionResult> GetPercent([FromQuery] string sequence = "ATCG")
        {
            //percent muestra el porcentaje de bases, A / T y C/ G de una secuencia
            //'http://localhost:8787/p/df91a627/percent/?seq=ACGT'
            var url = $"{_plumberBaseUrl}/percent/?seq={sequence}";
            var response = await _httpClient.GetStringAsync(url);

            return Ok(response);
        }

        [HttpGet("detail")]
        public async Task<IActionResult> GetDetail([FromQuery] string gene_symbol = "DHCR7")
        {
            
            //detail muestra info de un gen, dado su symbol
            //'http://localhost:8787/p/df91a627/detail/?symbol=DHCR7'
            var url = $"{_plumberBaseUrl}/detail/?symbol={gene_symbol.ToUpper()}";
            var response = await _httpClient.GetStringAsync(url);

            return Ok(response);
        }

        [HttpGet("sequence_by_range")]
        public async Task<IActionResult> GetSequenceByRange([FromQuery] string chrom = "chr11", [FromQuery] int start = 71428193, [FromQuery] int end = 71452868)
        {
            //seq_by_range devuelve la secuencia dado el cromosoma y el rango
            //'http://localhost:8787/p/df91a627/seq_by_range/?chrom=chr11&start=71428193&end=71452868'
            var url = $"{_plumberBaseUrl}/seq_by_range/?chrom={chrom}&start={start}&end={end}";

            //            var response = await _httpClient.GetStringAsync(url);
            // Trae la respuesta ya deserializada a un objeto
            var response = await _httpClient.GetFromJsonAsync<object>(url);

            return Ok(response);
        }

        [HttpGet("align")]
        public async Task<IActionResult> GetAlign([FromQuery] string pattern = "ATCG", [FromQuery] string subject = "ATCG", [FromQuery] bool global = true)
        {
            //align devuelve el alineamiento global o local de dos secuecias
            //'http://localhost:8787/p/df91a627/align/?pattern=AAACC&subject=ACGTC&global=true'
            var url = $"{_plumberBaseUrl}/align/?pattern={pattern}&subject={subject}&global={global}";
            var response = await _httpClient.GetStringAsync(url);

            return Ok(response);
        }
    }
}
