using Application.DTO;

namespace Application
{
    public class ServiceFolding : IServiceFolding
    {
        private readonly INeurosnapClient _neurosnapClient; //neurosnap
        private readonly IPyClient _pyClient; //
        private readonly IPublicApiClient _publicClient; //
        public ServiceFolding(INeurosnapClient neurosnapClient, IPyClient pyClient, IPublicApiClient publicClient)
        {
            _neurosnapClient = neurosnapClient;
            _pyClient = pyClient;
            _publicClient = publicClient;
        }
        public async Task<string> GetEstructures(string jobId, string pdbId)
        {
            //neurosnap: AA -> prediccion
            var predictionPdb = await _neurosnapClient.GetPrediction(jobId);
            //protein data bank
            var referencePdb = await _publicClient.DownloadPdb(pdbId);
            //py: (prediccion, pdbid) -> align
            //var alignPdbs = await _pyClient.GetAlignProtein(predictionPdb, referencePdb);
            return predictionPdb;
        }
        public async Task<string> InitFoldingJob(string nucleotides, string frame)
        {
            //py: (seq, frame) -> AA
            //var aminoacidSequence = await _pyClient.GetAminoAcidSeq(nucleotides, frame);
            var aminoacidSequence = "MASKSQHNAPKVKSPNGKAGSQGQWGRAWEVDWFSLASIIFLLLFAPFIVYYFIMACDQYSCSLTAPALDIATGHASLADIWAKTPPVTAKAAQLYALWVSFQVLLYSWLPDFCHRFLPGYVGGVQEGAITPAGVVNKYAVNGLQAWLITHILWFVNAYLLSWFSPTIIF";
            var jobId = await _neurosnapClient.InitJob(aminoacidSequence);
            return jobId;
        }
        public async Task<string> GetFoldingStatus(string jobId)
        {
            var status = await _neurosnapClient.GetJobStatus(jobId);
            return status;
        }
    }
}
