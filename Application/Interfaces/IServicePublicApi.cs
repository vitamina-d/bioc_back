using Application.DTO.Public;

namespace Application
{
    public interface IServicePublicApi
    {
        public Task<ResponseNcbiDto> GetSummaryFromNcbi(string entrez, string type);
    }
}
