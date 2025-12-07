using Domain.DTO;
using Domain.DTO.Folding;
using Domain.Interfaces;
using System.Text.Json;

namespace Application.UseCase
{
    public class ServiceFolding(INeurosnapClient neurosnapClient, IPythonClient pythonClient, IPublicApiClient publicClient) : IServiceFolding
    {
        private readonly INeurosnapClient _neurosnapClient = neurosnapClient;
        private readonly IPythonClient _pythonClient = pythonClient;
        private readonly IPublicApiClient _publicClient = publicClient;
        public async Task<ResponseDto<byte[]?>> GetReference(string accession)
        {
            var urlEstructure = await _publicClient.GetUrlEstructure(accession);
            if (urlEstructure == null)
            {
                return new ResponseDto<byte[]?>
                {
                    Code = 400,
                    Message = "The 'accession' value has invalid format. It should be a valid UniProtKB accession",
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
        public async Task<ResponseDto<byte[]?>> GetPrediction(string accession, string jobId, string rank, string apiKey)
        {
            var urlEstructure = await _publicClient.GetUrlEstructure(accession);
            if (urlEstructure == null)
            {
                return new ResponseDto<byte[]?>
                {
                    Code = 400,
                    Message = "The 'accession' value has invalid format. It should be a valid UniProtKB accession",
                    Data = null
                };
            }
            var model = await _publicClient.DownloadEstructure(urlEstructure);
            var predictionFile = await _neurosnapClient.GetPrediction(jobId, rank, apiKey);
            
            var alignPdbs = await _pythonClient.GetAlignProtein(predictionFile, model);
            return new ResponseDto<byte[]?>
            {
                Code = 200,
                Message = $"Ok.",
                Data = alignPdbs,
            };
        }
        public async Task<ResponseDto<PLDDTNeurosnapDto?>> GetPredictionPLDDT(string jobId, string rank, string apiKey)
        {
            var metadata = await _neurosnapClient.DownloadpLDDT(jobId, rank, apiKey);
            var dto = JsonSerializer.Deserialize<PLDDTNeurosnapDto?>(metadata);
            return new ResponseDto<PLDDTNeurosnapDto?>
            {
                Code = 200,
                Message = $"Ok.",
                Data = dto,
            };
        }
        public async Task<ResponseDto<string?>> InitFoldingJob(string aminoacid, string apiKey)
        {
            var jobId = await _neurosnapClient.InitJob(aminoacid, apiKey);
            return new ResponseDto<string?>
            {
                Code = 200,
                Message = $"Ok.",
                Data = jobId
            };
        }
        public async Task<ResponseDto<string?>> GetFoldingStatus (string jobId, string apiKey)
        {
            var json = await _neurosnapClient.GetJobStatus(jobId, apiKey); // "\"completed\""
            var status = JsonSerializer.Deserialize<string>(json);
            return new ResponseDto<string?>
            {
                Code = 200,
                Message = $"Ok.",
                Data = status,
            };
        }
        public async Task<ResponseDto<Dictionary<string, double>?>> GetRanks(string jobId, string apiKey)
        {
            var uncertainty = await _neurosnapClient.GetRanks(jobId, apiKey);
            var ranks = JsonSerializer.Deserialize<DataRanksDto?>(uncertainty);
            return new ResponseDto<Dictionary<string, double>?>
            {
                Code = 200,
                Message = $"Ok.",
                Data = ranks?.Prot1,
            };
        }
    }
}
