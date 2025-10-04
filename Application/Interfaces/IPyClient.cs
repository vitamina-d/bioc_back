using Application.DTO;

namespace Application
{
    public interface IPyClient
    {
        public DataAADto GetAASeq(string sequence, string frame);
        public DataPdbDto[] GetPdbs(DataPdbDto prediction, string pbdId);
    }
}
