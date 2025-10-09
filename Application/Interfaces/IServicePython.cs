using Application.DTO;
using Application.DTO.Python;

namespace Application
{
    public interface IServicePython
    {
        public Task<ResponseDto<SequenceDto?>> ReverseComplement(string sequence, bool reverse, bool complement);
        public Task<ResponseDto<SequenceDto?>> Translate(string sequence, int frame);
        public Task<ResponseDto<BodyAlignPdbDto?>> AlignPdb(byte[] prediction_pdb, byte[] reference_pdb);

    }
}
