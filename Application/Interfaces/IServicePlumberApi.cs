using Application.DTO;

namespace Application
{
    public interface IServicePlumberApi
    {
        public Task<AlignResponseDto> GetAlignment(string pattern, string subject, bool global);
        public Task<DetailResponseDto> GetDetail(string gene_symbol);
        public Task<EchoResponseDto> GetMessage(string msg);
        public Task<PercentResponseDto> GetPercent(string sequence);
        public Task<SeqByRangeResponseDto> GetSequence(string chrom, int start, int end);
        public Task<SeqBySymbolResponseDto> GetSequence(string gene_symbol, bool complete);

    }
}
