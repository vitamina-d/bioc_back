using Application.DTO;

namespace Application
{
    public interface IServicePublicApi
    {
        public Task<EnsemblResponseDto> GetSequenceFromEnsembl(string chrom, int start, int end);

        public Task<NcbiResponseDto> GetSummaryFromNcbi(string entrez, string type);
    }
}
