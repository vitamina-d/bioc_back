using Domain.DTO.Plumber;
using Domain.Interfaces;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Query
{
    public class PlumberApiClient(HttpClient httpClient) : BaseClient(httpClient), IPlumberApiClient
    {
        // GET
        public async Task<string> IsEntrez(string entrez)
        {
            var url = $"isentrez/?entrez={entrez}";
            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);
            return response;
        }
        public async Task<string> GetAutoComplete(string input)
        {
            var url = $"autocomplete/?input={input}";
            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);
            return response;
        }
        public async Task<string> GetDetail(string entrez, bool full)
        {
            string type = "detail";
            if (full)
            {
                type = "detailfull";
            }
            var url = $"{type}/?entrez={entrez}";
            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);
            return response;
        }
        public async Task<string> GetEntrez(string symbolOrAlias)
        {
            var url = $"entrez/?value={symbolOrAlias}";
            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);
            return response;
        }
        public async Task<string> GetSequence(string entrez, bool complete)
        {
            var url = $"sequence/?entrez={entrez}&complete={complete}";
            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);
            return response;
        }
        public async Task<string> GetSequence(string chrom, int start, int end)
        {
            var url = $"sequence_range/?chrom=chr{chrom}&start={start}&end={end}";
            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);
            return response;
        }
        public async Task<string> GetStats(string entrez, bool complete)
        {
            var url = $"stats/?entrez={entrez}&complete={complete}";
            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);
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
            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.PostAsync(url, content);
            }, url);
            return response;
        }
        public async Task<string> GetPercent(string sequence)
        {
            var url = "percent/";
            var body = new { seq = sequence };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.PostAsync(url, content);
            }, url);
            return response;
        }
    }
}
    