namespace Application
{
    public interface IPythonClient
    {
        
        public Task<string> GetAminoAcidSeq(string sequence, int frame);
        public Task<string> GetAlignProtein(string prediction_pdb, string reference_pdb);
        public Task<string> GetReverseComplement(string sequence, bool reverse, bool complement);

    }
}
