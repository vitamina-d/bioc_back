using Application.DTO;
using System.Text.Json.Serialization;

namespace Application
{
    public interface IPlumberApiClient
    {
        public Task<string> GetAlign(string pattern, string subject, bool global);
        public Task<string> GetEcho(string msg);
        public Task<string> GetDetail(string entrez);
        public Task<string> GetPercent(string sequence);
        public Task<string> GetSequence(string chrom, int start, int end);
        public Task<string> GetSequence(string entrez, bool complete);
        public Task<string> GetEntrez(string symbolOrAlias);
        public Task<string> IsEntrez(string entrez);
        public Task<ResponsePlumberDto<DataTableDto>> GetTable();

    }
}
