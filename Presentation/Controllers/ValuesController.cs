using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ValuesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(new { value = "value"});
        }

        [HttpGet("plumber")]
        public async Task<string> Plumber([FromQuery] string msj)
        {
            // La URL de la API Plumber con el parámetro msj
            
            var url = $"http://localhost:8000/echo?msj={Uri.EscapeDataString(msj)}";

            // Realizar la solicitud GET a la API Plumber
            var response = await _httpClient.GetStringAsync(url);

            return response;
        }
    }
}
