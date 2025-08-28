using Application.DTO;

namespace Application
{
    public interface IServicePlumberApi
    {
        public Task<ResponsePlumberDto<DataAlignDto>> GetAlignment(BodyAlignDto bodyDto);
        public Task<ResponsePlumberDto<DataComplementDto>> GetComplement(BodyComplementDto bodyDto);
        public Task<ResponsePlumberDto<DataPercentDto>> GetPercent(string sequence);


        public Task<ResponsePlumberDto<DataDetailDto>> GetDetail(string value, bool full);
        public Task<ResponsePlumberDto<DataSequenceDto>> GetSequence(string chrom, int start, int end);
        public Task<ResponsePlumberDto<DataSequenceDto>> GetSequence(string value, bool complete);
        
        public Task<ResponsePlumberDto<DataTableDto>> GetTable();
        public Task<ResponsePlumberDto<DataTableDto>> GetGenenames();

        public Task<EchoResponseDto> GetMessage(string msg);
    }
}
