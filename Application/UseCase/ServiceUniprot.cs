using Domain;
using Domain.DTO;

namespace Application
{
    public class ServiceUniprot : IServiceUniprot
    {
        private readonly IPublicApiClient _publicClient;
        public ServiceUniprot(IPublicApiClient publicApiClient)
        {
            _publicClient = publicApiClient;
        }

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