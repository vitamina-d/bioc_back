using Domain.DTO;
using Domain.Interfaces;

namespace Application.UseCase
{
    public class ServiceUniprot(IPublicApiClient publicApiClient) : IServiceUniprot
    {
        private readonly IPublicApiClient _publicClient = publicApiClient;

        public async Task<ResponseDto<byte[]?>> GetEstructure(string uniprotId)
        {
            var urlEstructure = await _publicClient.GetUrlEstructure(uniprotId);
            if (urlEstructure == null)
            {
                return new ResponseDto<byte[]?>
                {
                    Code = 400,
                    Message = "The 'uniprotId' is invalid.",
                    Data = null
                };
            }
            var model = await _publicClient.DownloadEstructure(urlEstructure);
            return new ResponseDto<byte[]?>
            {
                Code = 200,
                Message = $"Ok.",
                Data = model,
            };
        }
    }
}