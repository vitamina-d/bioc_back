using Application.DTO;

namespace Application
{
    public interface IPublicApiClient
    {
        public Task<ResponseEnsemblDto> GetEnsemblResponse(string chrom, int start, int end);

        public Task<string> GetNcbiResponse(string entrez, string type);
    }
}
