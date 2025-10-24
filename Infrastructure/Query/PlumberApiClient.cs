using Application;
using Application.DTO.Plumber;
using System.Text;
using System.Text.Json;


namespace Infrastructure.Query
{
    public class PlumberApiClient : BaseClient, IPlumberApiClient
    {
        public PlumberApiClient(HttpClient httpClient) : base(httpClient) { }
        
        // GET
        public async Task<string> IsEntrez(string entrez)
        {
            var url = $"isentrez/?entrez={entrez}";
            return await HandlerTryCatch(() => _httpClient.GetStringAsync(url), url);

        }
        public async Task<string> GetAutoComplete(string input)
        {
            var url = $"autocomplete/?input={input}";
            return await HandlerTryCatch(() => _httpClient.GetStringAsync(url), url);
        }

        public async Task<string> GetDetail(string entrez, bool full)
        {
            string type = "detail";
            if (full)
            {
                type = "detailfull";
            }
            var url = $"{type}/?entrez={entrez}";
            return await HandlerTryCatch(() => _httpClient.GetStringAsync(url), url);
        }
        public async Task<string> GetEntrez(string symbolOrAlias)
        {
            var url = $"entrez/?value={symbolOrAlias}";
            return await HandlerTryCatch(() => _httpClient.GetStringAsync(url), url);
        }
        public async Task<string> GetSequence(string entrez, bool complete)
        {
            // seq_by_symbol devuelve la secuencia completa o de exones, dado el symbol de un gen
            //'http://localhost:8787/p/df91a627/seq_by_symbol/?gene_symbol=DHCR7&complete=true'
            var url = $"sequence/?entrez={entrez}&complete={complete}";
            return await HandlerTryCatch(() => _httpClient.GetStringAsync(url), url);
        }

        public async Task<string> GetSequence(string chrom, int start, int end) //chrom= 11, 12, X, Y
        {
            var url = $"seq_by_range/?chrom=chr{chrom}&start={start}&end={end}";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }
        public async Task<string> GetStats(string entrez, bool complete)
        {
            var url = $"stats/?entrez={entrez}&complete={complete}";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }


        //POST
        public async Task<string> GetAlign(string pattern, string subject, string type, int gapOpening, int gapExtension)
        {
            var url = "align/";
            var body = new BodyAlignDto
            {
                Pattern = pattern,
                Subject = subject,
                Type = type,
                GapOpening = gapOpening,
                GapExtension = gapExtension
            };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            var response = await HandlerTryCatch(async () =>
            {
                var httpResponse = await _httpClient.PostAsync(url, content);
                httpResponse.EnsureSuccessStatusCode(); //HttpRequestException
                return await httpResponse.Content.ReadAsStringAsync();
            }, url);
            return response;
        }
        public async Task<string> GetPercent(string sequence)
        {
            //percent muestra el porcentaje de bases, A / T y C/ G de una secuencia
            //'http://localhost:8787/p/df91a627/percent/?seq=ACGT'
            var url = "percent/";
            var body = new { seq = sequence };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            var response = await HandlerTryCatch(async () =>
            {
                var httpResponse = await _httpClient.PostAsync(url, content);
                httpResponse.EnsureSuccessStatusCode(); //HttpRequestException
                return await httpResponse.Content.ReadAsStringAsync();
            }, url);
            return response;
        }
    }
}
    