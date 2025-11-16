namespace Application
{
    public interface IPublicApiClient
    {
        public Task<string> GetNcbiResponse(string entrez, string type);
        public Task<byte[]> DownloadPdb(string pdbId);
        public Task<string?> GetAlphaFoldId(string accession);
        public Task<byte[]> DownloadModel(string alphafoldId); 
        public Task<string> DownloadpLDDT(string alphafoldId); 


    }
}
