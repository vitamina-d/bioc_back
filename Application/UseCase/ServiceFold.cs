using Application.DTO;

namespace Application
{
    public class ServiceFold : IServiceFold
    {
        private readonly IFoldClient _foldClient; //neurosnap
        private readonly IPyClient _pyClient; //
        public ServiceFold(IFoldClient foldClient, IPyClient pyClient)
        {
            _foldClient = foldClient;
            _pyClient = pyClient;
        }

        public DataPdbDto[] GetEstructures(BodyFoldDto body)
        {
            //py: (seq, frame) -> AA
            var transcript = _pyClient.GetAASeq(body.Sequence, body.Frame);
            
            //neurosnap: AA -> prediccion
            var prediction = _foldClient.GetEstructures(transcript.Sequence);
            
            //py: (prediccion, pdbid) -> align
            var pdbs = _pyClient.GetPdbs(prediction, body.PbdId);
            return pdbs;
        }
    }
}
