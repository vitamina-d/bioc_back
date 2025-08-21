using Application;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Infrastructure.Query
{
    public class PlumberApiClient : IPlumberApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _plumberURL;


        public PlumberApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _plumberURL = "http://host.docker.internal:8000";
        }

        public async Task<string> GetAlign(string pattern, string subject, bool global)
        {
            //align devuelve el alineamiento global o local de dos secuecias
            //'http://localhost:8787/p/df91a627/align/?pattern=AAACC&subject=ACGTC&global=true'
            var url = $"{_plumberURL}/align/?pattern={pattern}&subject={subject}&global={global}";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }

        public async Task<string> GetDetail(string gene_symbol)
        {
            //detail muestra info de un gen, dado su symbol
            //'http://localhost:8787/p/df91a627/detail/?symbol=DHCR7'
            var url = $"{_plumberURL}/detail/?symbol={gene_symbol.ToUpper()}";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }

        public async Task<string> GetEcho(string msg)
        {
            var url = $"{_plumberURL}/echo/?msg={Uri.EscapeDataString(msg)}";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }

        public async Task<string> GetPercent(string sequence)
        {
            //percent muestra el porcentaje de bases, A / T y C/ G de una secuencia
            //'http://localhost:8787/p/df91a627/percent/?seq=ACGT'
            var url = $"{_plumberURL}/percent/?seq={sequence}";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }

        public async Task<string> GetSequence(string gene_symbol, bool complete)
        {
            // seq_by_symbol devuelve la secuencia completa o de exones, dado el symbol de un gen
            //'http://localhost:8787/p/df91a627/seq_by_symbol/?gene_symbol=DHCR7&complete=true'
            var url = $"{_plumberURL}/seq_by_symbol/?gene_symbol={gene_symbol.ToUpper()}&complete={complete}";
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
    }
}
