using Application.DTO;
using Application.DTO.Public;

namespace Application
{
    public interface IServicePublicApi
    {
        public Task<ResponseDto<ResponseNcbiDto?>> GetSummaryFromNcbi(string entrez, string type);
    }
}
