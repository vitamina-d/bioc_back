namespace Domain.Interfaces
{
    public interface IPythonClient
    {
        public Task<string> GetAminoAcidSeq(string sequence, int frame);
        public Task<byte[]> GetAlignProtein(byte[] prediction_pdb, byte[] reference_pdb);
        public Task<string> GetReverseComplement(string sequence, bool reverse, bool complement);

    }
}
