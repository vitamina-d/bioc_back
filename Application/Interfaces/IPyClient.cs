using Application.DTO;

namespace Application
{
    public interface IPyClient
    {
        
        public Task<string> GetAminoAcidSeq(string sequence, string frame);
        public Task<string> GetAlignProtein(string prediction, string reference);
    }
}
