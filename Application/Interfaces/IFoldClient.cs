using Application.DTO;

namespace Application
{
    public interface IFoldClient
    {
        public DataPdbDto GetEstructures(string sequence);

    }
}
