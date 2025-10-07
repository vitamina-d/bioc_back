using Application.DTO;
using Application.DTO.Plumber;

namespace Application
{
    public interface IServicePlumberApi
    {
        public Task<ResponseDto<DataAlignDto?>> GetAlignment(string pattern, string subject, string type, int gapOpening, int gapExtension);
        public Task<ResponseDto<DataPercentDto?>> GetPercent(string sequence);


        public Task<ResponseDto<T?>> GetDetail<T>(string value, bool full);
        public Task<ResponseDto<DataSequenceDto?>> GetSequence(string chrom, int start, int end);
        public Task<ResponseDto<DataSequenceDto?>> GetSequence(string entrez, bool complete);
        public Task<ResponseDto<DataStatsDto?>> GetStats(string entrez, bool complete);

        public Task<ResponseDto<List<string>>> GetAutoComplete(string input);
        public Task<ResponseDto<DataEntrezDto>> GetEntrezByValue(string value);

        public Task<EchoResponseDto> GetMessage(string msg);
    }
}
