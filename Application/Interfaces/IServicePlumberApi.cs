using Application.DTO;

namespace Application
{
    public interface IServicePlumberApi
    {
        public Task<AlignResponseDto> GetAlignment(AlignBodyDto bodyDto);
        public Task<DetailResponseDto> GetDetail(string value);
        //public Task<EchoResponseDto> GetMessage(string msg);
        public Task<PercentResponseDto> GetPercent(string sequence);
        public Task<SeqByRangeResponseDto> GetSequence(string chrom, int start, int end);
        public Task<SeqBySymbolResponseDto> GetSequence(string value, bool complete);

    }
}
