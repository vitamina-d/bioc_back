using Domain.DTO;
using Domain.DTO.Python;

namespace Domain.Interfaces
{
    public interface IServicePython
    {
        public Task<ResponseDto<SequenceDto?>> ReverseComplement(string sequence, bool reverse, bool complement);
        public Task<ResponseDto<SequenceDto?>> Translate(string sequence, int frame);
        public Task<ResponseDto<byte[]?>> ComparePdb(byte[] prediction_pdb, string reference_id);

    }
}
