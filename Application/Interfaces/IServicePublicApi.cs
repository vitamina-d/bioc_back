using Application.DTO;

namespace Application
{
    public interface IServicePublicApi
    {
        public Task<ResponseEnsemblDto> GetSequenceFromEnsembl(string chrom, int start, int end);

        public Task<ResponseNcbiDto> GetSummaryFromNcbi(string entrez, string type);
    }
}
