using Application.DTO;
using Application.Interfaces.DTO;

namespace Application
{
    public interface IServicePlumberApi
    {
        public Task<ResponsePlumberDto<DataAlignDto?>> GetAlignment(BodyAlignDto bodyDto);
        public Task<ResponsePlumberDto<DataComplementDto?>> GetComplement(BodyComplementDto bodyDto);
        public Task<ResponsePlumberDto<DataPercentDto?>> GetPercent(string sequence);


        public Task<ResponsePlumberDto<T?>> GetDetail<T>(string value, bool full);
        public Task<ResponsePlumberDto<DataSequenceDto?>> GetSequence(string chrom, int start, int end);
        public Task<ResponsePlumberDto<DataSequenceDto?>> GetSequence(string entrez, bool complete);
        public Task<ResponsePlumberDto<DataStatsDto?>> GetStats(string entrez, bool complete);

        public Task<ResponsePlumberDto<List<string>>> GetAutoComplete(string input);
        public Task<ResponsePlumberDto<DataEntrezDto>> GetEntrezByValue(string value);


        public Task<ResponsePlumberDto<DataTableDto?>> GetTable();
        public Task<ResponsePlumberDto<DataTableDto?>> GetGenenames();

        public Task<EchoResponseDto> GetMessage(string msg);
    }
}
