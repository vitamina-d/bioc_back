using Application.DTO;

namespace Application
{
    public interface IServicePlumberApi
    {
        public Task<ResponsePlumberDto<DataAlignDto>> GetAlignment(BodyAlignDto bodyDto);
        public Task<ResponsePlumberDto<DataDetailDto>> GetDetail(string value);
        //public Task<EchoResponseDto> GetMessage(string msg);
        public Task<ResponsePlumberDto<DataPercentDto>> GetPercent(string sequence);
        public Task<ResponsePlumberDto<DataSequenceDto>> GetSequence(string chrom, int start, int end);
        public Task<ResponsePlumberDto<DataSequenceDto>> GetSequence(string value, bool complete);
        public Task<ResponsePlumberDto<DataTableDto>> GetTable();


    }
}
