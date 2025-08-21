using Application.DTO;

namespace Application
{
    public interface IPublicApiClient
    {
        public Task<EnsemblResponseDto> GetEnsemblResponse(string chrom, int start, int end);

        public Task<string> GetNcbiResponse(string entrez, string type);
    }
}
