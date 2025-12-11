namespace Domain.Interfaces
{
    public interface IPlumberApiClient
    {
        public Task<string> GetAlign(string pattern, string subject, string type, int gapOpening, int gapExtension);
        public Task<string> GetDetail(string entrez, bool full);
        public Task<string> GetPercent(string sequence);
        public Task<string> GetSequence(string chrom, int start, int end);
        //public Task<string> GetSequence(string entrez, bool complete);
        //public Task<string> GetStats(string entrez, bool complete);
        public Task<string> GetEntrez(string symbolOrAlias);
        public Task<string> IsEntrez(string entrez);
        public Task<string> GetAutoComplete(string input);
    }
}
