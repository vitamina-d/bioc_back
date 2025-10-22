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
            try
            {
                var response = await _pythonClient.GetAlignProtein(prediction_pdb, reference_pdb);
                var json = JsonSerializer.Deserialize<ResponseDto<BodyAlignPdbDto?>>(response);
                if (json == null)
                {
                    return new ResponseDto<BodyAlignPdbDto?>
                    {
                        Code = 500,
                        Message = $"Error en deserialización."
                    };
                }
                return json;
            }
            catch (TaskCanceledException ex)
            {
                return new ResponseDto<BodyAlignPdbDto?>
                {
                    Code = 504,
                    Message = $"Timeout: {ex.Message}"
                };
            }
            catch (HttpRequestException ex)
            {
                return new ResponseDto<BodyAlignPdbDto?>
                {
                    Code = 502,
                    Message = $"Error HTTP: {ex.Message}"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<BodyAlignPdbDto?>
                {
                    Code = 500,
                    Message = $"Error de servicio: {ex.Message}"
                };
            }
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

            try
            {
                var response = await _pythonClient.GetReverseComplement(sequence, reverse, complement);
                var json = JsonSerializer.Deserialize<ResponseDto<SequenceDto?>>(response);
                if (json == null)
                {
                    return new ResponseDto<SequenceDto?>
                    {
                        Code = 500,
                        Message = $"Error en deserialización."
                    };
                }
                return json;
            }
            catch (TaskCanceledException ex)
            {
                return new ResponseDto<SequenceDto?>
                {
                    Code = 504,
                    Message = $"Timeout: {ex.Message}"
                };
            }
            catch (HttpRequestException ex)
            {
                return new ResponseDto<SequenceDto?>
                {
                    Code = 502,
                    Message = $"Error HTTP: {ex.Message}"
                };
            }
            
            catch (Exception ex)
            {
                return new ResponseDto<SequenceDto?>
                {
                    Code = 500,
                    Message = $"Error de servicio: {ex.Message}"
                };
            }
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
            try
            {
                var response = await _pythonClient.GetAminoAcidSeq(sequence, frame);
                var json = JsonSerializer.Deserialize<ResponseDto<SequenceDto?>>(response);
                if (json == null)
                {
                    return new ResponseDto<SequenceDto?>
                    {
                        Code = 500,
                        Message = $"Error en deserialización."
                    }; 
                }
                return json;
            } 
            catch (TaskCanceledException ex)
            {
                return new ResponseDto<SequenceDto?>
                {
                    Code = 504,
                    Message = $"Timeout: {ex.Message}"
                };
            }
            catch (HttpRequestException ex)
            {
                return new ResponseDto<SequenceDto?>
                {
                    Code = 502,
                    Message = $"Error HTTP: {ex.Message}"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<SequenceDto?>
                {
                    Code = 500, 
                    Message = $"Error de servicio: {ex.Message}"
                };
            }
        }
    }
}
