namespace Application
{
    public class ServiceFolding : IServiceFolding
    {
        private readonly INeurosnapClient _neurosnapClient; //neurosnap
        private readonly IPythonClient _pythonClient; //biopython
        private readonly IPublicApiClient _publicClient; //page
        public ServiceFolding(INeurosnapClient neurosnapClient, IPythonClient pythonClient, IPublicApiClient publicClient)
        {
            _neurosnapClient = neurosnapClient;
            _pythonClient = pythonClient;
            _publicClient = publicClient;
        }
        public async Task<byte[]> GetEstructures(string pdbId, string jobId, string rank)
        {
            //get prediction_pdb from neurosnap
            var predictionFile = await _neurosnapClient.GetPrediction(jobId, rank);
            
            //download reference_pdb from protein data bank
            var referencePdb = await _publicClient.DownloadPdb(pdbId);

            //py: (prediccion, pdbid) -> align
            var alignPdbs = await _pythonClient.GetAlignProtein(predictionFile, referencePdb);
            return alignPdbs;
        }
        public async Task<string> InitFoldingJob(string aminoacidSequence)
        {
            //py: (seq, frame) -> AA
            //var aminoacidSequence = await _pythonClient.GetAminoAcidSeq(nucleotides, frame); NO HACE FALTA
            var jobId = await _neurosnapClient.InitJob(aminoacidSequence);
            return jobId;
        }
        public async Task<string> GetFoldingStatus(string jobId)
        {
            var status = await _neurosnapClient.GetJobStatus(jobId);
            return status;
        }

        public async Task<string> GetRanks(string jobId)
        {
            var uncertainty = await _neurosnapClient.GetRanks(jobId);
            //desserializar
            return uncertainty; //{"prot1": {"1": 7.8, "2": 4.97, "3": 4.71, "4": 5.85, "5": 6.44}} rank_1 al 5

        }
    }
}
