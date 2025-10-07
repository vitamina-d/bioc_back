using Application.DTO;
using Application.DTO.Python;
using System.Text.Json;

namespace Application
{
    public class ServicePython : IServicePython
    {
        private readonly IPythonClient _pythonClient;
        public ServicePython(IPythonClient pythonClient)
        {
            _pythonClient = pythonClient;
        }

        public async Task<ResponseDto<BodyAlignPdbDto?>> AlignPdb(string prediction_pdb, string reference_pdb)
        {
            var res = await _pythonClient.GetAlignProtein(prediction_pdb, reference_pdb);
            var json = JsonSerializer.Deserialize<ResponseDto<BodyAlignPdbDto>>(res);
            return json;
        }

        public async Task<ResponseDto<SequenceDto?>> ReverseComplement(string sequence, bool reverse, bool complement)
        {
            var res = await _pythonClient.GetReverseComplement(sequence, reverse, complement);
            var json = JsonSerializer.Deserialize<ResponseDto<SequenceDto>>(res);
            return json;
        }

        public async Task<ResponseDto<SequenceDto?>> Translate(string sequence, int frame)
        {
            var res = await _pythonClient.GetAminoAcidSeq(sequence, frame);
            var json = JsonSerializer.Deserialize<ResponseDto<SequenceDto>>(res);
            return json;
        }
    }
}
