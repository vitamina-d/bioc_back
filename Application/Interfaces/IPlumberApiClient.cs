using Application.DTO;

namespace Application
{
    public interface IPlumberApiClient
    {
        public Task<string> GetAlign(BodyAlignDto bodyDto);
        public Task<string> GetEcho(string msg);
        public Task<string> GetDetail(string entrez, bool full);
        public Task<string> GetPercent(string sequence);
        public Task<string> GetSequence(string chrom, int start, int end);
        public Task<string> GetSequence(string entrez, bool complete);
        public Task<string> GetEntrez(string symbolOrAlias);
        public Task<string> IsEntrez(string entrez);
        public Task<ResponsePlumberDto<DataTableDto?>> GetTable();
        public Task<ResponsePlumberDto<DataTableDto?>> GetGenenames();
        public Task<ResponsePlumberDto<DataComplementDto?>> GetComplement(BodyComplementDto bodyDto);


    }
}
