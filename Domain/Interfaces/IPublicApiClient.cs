namespace Domain
{
    public interface IPublicApiClient
    {
        public Task<string> GetNcbiResponse(string entrez, string type);
        public Task<byte[]> DownloadPdb(string pdbId);
        //public Task<byte[]> DownloadModel(string alphafoldId); 
        
        public Task<string> DownloadpLDDT(string alphafoldId);
        public Task<string?> GetUrlEstructure(string accession);
        public Task<byte[]> DownloadEstructure(string url); //experimental(pdb) o csm (accession)


    }
}
