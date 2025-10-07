namespace Application
{
    public interface IPublicApiClient
    {
        public Task<string> GetNcbiResponse(string entrez, string type);
        public Task<string> DownloadPdb(string pdbId);

    }
}
