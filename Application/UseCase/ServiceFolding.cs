using Application.DTO;
using Application.DTO.Folding;
using System.Text.Json;

namespace Application
{
    public class ServiceFolding : IServiceFolding
    {
        private readonly INeurosnapClient _neurosnapClient;
        private readonly IPythonClient _pythonClient;
        private readonly IPublicApiClient _publicClient;
        public ServiceFolding(INeurosnapClient neurosnapClient, IPythonClient pythonClient, IPublicApiClient publicClient)
        {
            _neurosnapClient = neurosnapClient;
            _pythonClient = pythonClient;
            _publicClient = publicClient;
        }
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
        public async Task<ResponseDto<pLDDTRcsbDto?>> GetModelPLDDT(string accession)
        {
            var metadata = await _publicClient.DownloadpLDDT(accession);
            var dto = JsonSerializer.Deserialize<pLDDTRcsbDto?>(metadata);
            return new ResponseDto<pLDDTRcsbDto?>
            {
                Code = 200,
                Message = $"Ok.",
                Data = dto,
            };
        }
        public async Task<ResponseDto<byte[]?>> GetPrediction(string accession, string jobId, string rank, string apiKey)
        {
            //de donde descargo el accession?
            //pdb experimental (id de 4 caracteres) 
            //alphafold  AF-P12345-F1 
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
            
            //py: (prediccion, pdbid) -> align
            var alignPdbs = await _pythonClient.GetAlignProtein(predictionFile, model);
            return new ResponseDto<byte[]?>
            {
                Code = 200,
                Message = $"Ok.",
                Data = alignPdbs,
            };
        }
        public async Task<ResponseDto<pLDDTNeurosnapDto?>> GetPredictionPLDDT(string jobId, string rank, string apiKey)
        {
            var metadata = await _neurosnapClient.DownloadpLDDT(jobId, rank, apiKey);
            var dto = JsonSerializer.Deserialize<pLDDTNeurosnapDto?>(metadata);
            return new ResponseDto<pLDDTNeurosnapDto?>
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
            }; //{"prot1": {"1": 7.8, "2": 4.97, "3": 4.71, "4": 5.85, "5": 6.44}}

        }

        public async Task<ResponseDto<string?>> GetJob(string jobId, string apiKey)
        {
            var job = await _neurosnapClient.GetJob(jobId, apiKey);
           
            return new ResponseDto<string?>
            {
                Code = 200,
                Message = $"Ok.",
                Data = job,
            };
        }

       
    }
}
