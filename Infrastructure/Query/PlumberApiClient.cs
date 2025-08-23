using Application;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;


namespace Infrastructure.Query
{
    public class PlumberApiClient : IPlumberApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _plumberURL;



        public PlumberApiClient(HttpClient httpClient, IConfiguration configuration )
        {
            _httpClient = httpClient;
            _plumberURL = configuration["API_URL:PLUMBER"];

        }

        public async Task<string> GetAlign(string pattern, string subject, bool global)
        {
            //align devuelve el alineamiento global o local de dos secuecias
            //'http://localhost:8787/p/df91a627/align/?pattern=AAACC&subject=ACGTC&global=true'
            //var url = $"{_plumberURL}/align/?pattern={pattern}&subject={subject}&global={global}";
            var url = $"{_plumberURL}/align/";
            //var response = await _httpClient.GetStringAsync(url);
            var body = new { pattern = pattern, subject = subject, global = global };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();
            return result;

        }

        public async Task<string> GetDetail(string entrez)
        {
            //detail muestra info de un gen, dado su symbol
            //'http://localhost:8787/p/df91a627/detail/?symbol=DHCR7'
            var url = $"{_plumberURL}/detail/?symbol={entrez}";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }

        public async Task<string> GetEcho(string msg)
        {
            var url = $"{_plumberURL}/echo/?msg={Uri.EscapeDataString(msg)}";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }

        public async Task<string> GetEntrez(string symbolOrAlias)
        {
            var url = $"{_plumberURL}/entrez/?value={symbolOrAlias}";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }

        public async Task<string> GetPercent(string sequence)
        {
            //percent muestra el porcentaje de bases, A / T y C/ G de una secuencia
            //'http://localhost:8787/p/df91a627/percent/?seq=ACGT'
            var url = $"{_plumberURL}/percent/";
            var body = new { seq = sequence };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> GetSequence(string entrez, bool complete)
        {
            // seq_by_symbol devuelve la secuencia completa o de exones, dado el symbol de un gen
            //'http://localhost:8787/p/df91a627/seq_by_symbol/?gene_symbol=DHCR7&complete=true'
            var url = $"{_plumberURL}/sequence/?entrez={entrez}&complete={complete}";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }

        public async Task<string> GetSequence(string chrom, int start, int end)
        {
            //seq_by_range devuelve la secuencia dado el cromosoma y el rango
            //'http://localhost:8787/p/df91a627/seq_by_range/?chrom=chr11&start=71428193&end=71452868'
            var url = $"{_plumberURL}/seq_by_range/?chrom={chrom}&start={start}&end={end}";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }

        public async Task<string> IsEntrez(string entrez)
        {
            var url = $"{_plumberURL}/isentrez/?entrez={entrez}";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }
    }
}
