using Domain.DTO;
using Domain.DTO.Plumber;

namespace Domain.Interfaces
{
    public interface IServicePlumberApi
    {
        public Task<ResponseDto<string[]?>> GetAutoComplete(string input);
        public Task<ResponseDto<DataDetailDto?>> GetDetail(string value);
        public Task<ResponseDto<DataFullDetailDto?>> GetFullDetail(string value);
        public Task<ResponseDto<DataAlignDto?>> GetAlignment(string pattern, string subject, string type, int gapOpening, int gapExtension);
        public Task<ResponseDto<DataStatsDto?>> GetPercent(string sequence);
        public Task<ResponseDto<DataSequenceDto[]?>> GetSequence(string chrom, int start, int end);
        public Task<ResponseDto<DataSequenceDto[]?>> GetSequence(string entrez, bool complete);
        public Task<ResponseDto<DataStatsDto?>> GetStats(string entrez, bool complete);
        public Task<ResponseDto<DataEntrezDto?>> GetEntrezByValue(string value);
    }
}
