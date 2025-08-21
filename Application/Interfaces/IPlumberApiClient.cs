using System.Text.Json.Serialization;

namespace Application
{
    public interface IPlumberApiClient
    {
        public Task<string> GetEcho(string msg);
        public Task<string> GetSequence(string gene_symbol, bool complete);
        public Task<string> GetPercent(string sequence);
        public Task<string> GetDetail(string gene_symbol);
        public Task<string> GetSequence(string chrom, int start, int end);
        public Task<string> GetAlign(string pattern, string subject, bool global);
    }
}
