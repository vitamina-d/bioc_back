namespace Application
{
    public class ServiceFolding : IServiceFolding
    {
        private readonly INeurosnapClient _neurosnapClient; //neurosnap
        private readonly IPythonClient _pyClient; //biopython
        private readonly IPublicApiClient _publicClient; //page
        public ServiceFolding(INeurosnapClient neurosnapClient, IPythonClient pyClient, IPublicApiClient publicClient)
        {
            _neurosnapClient = neurosnapClient;
            _pyClient = pyClient;
            _publicClient = publicClient;
        }
        public async Task<string> GetEstructures(string jobId, string pdbId)
        {
            //get prediction_pdb from neurosnap
            var predictionPdb = await _neurosnapClient.GetPrediction(jobId);
            
            //download reference_pdb from protein data bank
            var referencePdb = await _publicClient.DownloadPdb(pdbId);

            //py: (prediccion, pdbid) -> align
            var alignPdbs = await _pyClient.GetAlignProtein(predictionPdb, referencePdb);
            return predictionPdb;
        }
        public async Task<string> InitFoldingJob(string nucleotides, int frame)
        {
            //py: (seq, frame) -> AA
            var aminoacidSequence = await _pyClient.GetAminoAcidSeq(nucleotides, frame);
            var jobId = "123456789";
            //var jobId = await _neurosnapClient.InitJob(aminoacidSequence);
            return jobId;
        }
        public async Task<string> GetFoldingStatus(string jobId)
        {
            var status = await _neurosnapClient.GetJobStatus(jobId);
            return status;
        }
    }
}
