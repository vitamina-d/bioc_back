namespace Domain.Interfaces
{
    public interface IPublicApiClient
    {
        public Task<string> GetNcbiResponse(string entrez, string type);
        public Task<byte[]> DownloadPdb(string pdbId);
        public Task<string?> GetUrlEstructure(string accession);
        public Task<byte[]> DownloadEstructure(string url);
    }
}
