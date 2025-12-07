using Domain.DTO;
using Domain.DTO.Python;
using Domain.Interfaces;
using System.Text.Json;

namespace Application.UseCase
{
    public class ServicePython(IPythonClient pythonClient, IPublicApiClient publicClient) : IServicePython
    {
        private readonly IPythonClient _pythonClient = pythonClient;
        private readonly IPublicApiClient _publicClient = publicClient;
        public async Task<ResponseDto<BodyAlignPdbDto?>> AlignPdb(byte[] prediction_pdb, byte[] reference_pdb)
        {
            if (prediction_pdb == null || prediction_pdb.Length == 0 )
            {
                return new ResponseDto<BodyAlignPdbDto?>
                {
                    Code = 400,
                    Message = "Ingrese prediction PDB."
                };
            }
            if (reference_pdb == null || reference_pdb.Length == 0 )
            {
                return new ResponseDto<BodyAlignPdbDto?>
                {
                    Code = 400,
                    Message = "Ingrese reference PDB."
                };
            }
            var response = await _pythonClient.GetAlignProtein(prediction_pdb, reference_pdb);
            var data = JsonSerializer.Deserialize<BodyAlignPdbDto?>(response);
            return new ResponseDto<BodyAlignPdbDto?>
            {
                Code = 200,
                Message = "Ok.",
                Data = data,
            }; 
        }
        public async Task<ResponseDto<byte[]?>> ComparePdb(byte[] pdb_file, string reference_id)
        {
            if (pdb_file == null || pdb_file.Length == 0)
            {
                return new ResponseDto<byte[]?>
                {
                    Code = 400,
                    Message = "Ingrese prediction PDB_file."
                };
            }
            if (reference_id == null || reference_id.Length == 0)
            {
                return new ResponseDto<byte[]?>
                {
                    Code = 400,
                    Message = "Ingrese reference ID."
                };
            }
            //download reference_pdb from protein data bank
            var referencePdb = await _publicClient.DownloadPdb(reference_id);
            var response = await _pythonClient.GetAlignProtein(pdb_file, referencePdb);
            return new ResponseDto<byte[]?>
            {
                Code = 200,
                Message = "Ok.",
                Data = response,
            };
        }
        public async Task<ResponseDto<SequenceDto?>> ReverseComplement(string sequence, bool reverse, bool complement)
        {
            if (sequence == null || sequence == "")
            {
                return new ResponseDto<SequenceDto?>
                {
                    Code = 400,
                    Message = "Ingrese secuencia."
                };
            }
            var response = await _pythonClient.GetReverseComplement(sequence, reverse, complement);
            var json = JsonSerializer.Deserialize<ResponseDto<SequenceDto?>>(response);
            return json;
        }
        public async Task<ResponseDto<SequenceDto?>> Translate(string sequence, int frame)
        {
            if (sequence == null || sequence == "")
            {
                return new ResponseDto<SequenceDto?>
                {
                    Code = 400,
                    Message = "Ingrese secuencia."
                };
            }
            if (Math.Abs(frame) < 1 || Math.Abs(frame) > 3)
            {
                return new ResponseDto<SequenceDto?>
                {
                    Code = 400,
                    Message = "Ingrese un frame valido."
                };
            }
            var response = await _pythonClient.GetAminoAcidSeq(sequence, frame);
            var json = JsonSerializer.Deserialize<ResponseDto<SequenceDto?>>(response);
            return json;
        }
    }
}
