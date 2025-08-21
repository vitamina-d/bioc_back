using Application.DTO;
using System.Text.Json;

namespace Application
{
    public class ServicePlumberApi : IServicePlumberApi
    {
        private readonly IPlumberApiClient _plumberApiClient;

        public ServicePlumberApi(IPlumberApiClient plumberApiClient)
        {
            _plumberApiClient = plumberApiClient;
        }

        public async Task<AlignResponseDto> GetAlignment(string pattern, string subject, bool global)
        {
            var res = await _plumberApiClient.GetAlign(pattern, subject, global);
            var json = JsonSerializer.Deserialize<AlignResponseDto>(res);
            return json;
        }

        public async Task<DetailResponseDto> GetDetail(string gene_symbol)
        {
            var res = await _plumberApiClient.GetDetail(gene_symbol);
            var json = JsonSerializer.Deserialize<DetailResponseDto>(res);
            return json;
        }

        public async Task<EchoResponseDto> GetMessage(string msg)
        {
            var res = await _plumberApiClient.GetEcho(msg);
            var json = JsonSerializer.Deserialize<EchoResponseDto>(res);
            return json;
        }

        public async Task<PercentResponseDto> GetPercent(string sequence)
        {
            var res = await _plumberApiClient.GetPercent(sequence);
            var dto = JsonSerializer.Deserialize<PercentResponseDto>(res);
            return dto;
        }

        public async Task<SeqBySymbolResponseDto> GetSequence(string chrom, int start, int end)
        {
            var res = await _plumberApiClient.GetSequence(chrom, start, end);
            var json = JsonSerializer.Deserialize<SeqBySymbolResponseDto>(res);
            return json;
        }

        public async Task<SeqByRangeResponseDto> GetSequence(string gene_symbol, bool complete)
        {
            var res = await _plumberApiClient.GetSequence(gene_symbol, complete);
            var json = JsonSerializer.Deserialize<SeqByRangeResponseDto>(res);
            return json;
        }
    }
}
