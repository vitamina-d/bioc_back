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
        public async Task<ResponseDto<byte[]?>> GetEstructures(string pdbId, string jobId, string rank)
        {
            //get prediction_pdb from neurosnap
            var predictionFile = await _neurosnapClient.GetPrediction(jobId, rank);
            
            //download reference_pdb from protein data bank
            var referencePdb = await _publicClient.DownloadPdb(pdbId);

            //py: (prediccion, pdbid) -> align
            var alignPdbs = await _pythonClient.GetAlignProtein(predictionFile, referencePdb);
            return new ResponseDto<byte[]?>
            {
                Code = 200,
                Message = $"Ok.",
                Data = alignPdbs,
            };
        }
        public async Task<ResponseDto<string?>> InitFoldingJob(string aminoacidSequence)
        {
            //py: (seq, frame) -> AA
            //var aminoacidSequence = await _pythonClient.GetAminoAcidSeq(nucleotides, frame); NO HACE FALTA
            var jobId = await _neurosnapClient.InitJob(aminoacidSequence);
            return new ResponseDto<string?>
            {
                Code = 200,
                Message = $"Ok.",
                Data = jobId
            };
        }
        public async Task<ResponseDto<string?>> GetFoldingStatus(string jobId)
        {
            var json = await _neurosnapClient.GetJobStatus(jobId); // "\"completed\""
            var status = JsonSerializer.Deserialize<string>(json);
            return new ResponseDto<string?>
            {
                Code = 200,
                Message = $"Ok.",
                Data = status,
            };
        }
        public async Task<ResponseDto<Dictionary<string, double>?>> GetRanks(string jobId)
        {
            var uncertainty = await _neurosnapClient.GetRanks(jobId);
            var ranks = JsonSerializer.Deserialize<DataRanksDto?>(uncertainty);
            //desserializar
            return new ResponseDto<Dictionary<string, double>?>
            {
                Code = 200,
                Message = $"Ok.",
                Data = ranks.Protein,
            }; //{"prot1": {"1": 7.8, "2": 4.97, "3": 4.71, "4": 5.85, "5": 6.44}}

        }
    }
}
