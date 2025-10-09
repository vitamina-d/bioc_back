using Application.DTO.Python;
using System.Text;
using System.Text.Json;

namespace Application
{
    public class PythonClient : IPythonClient
    {
        private readonly HttpClient _httpClient;
        public PythonClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetAminoAcidSeq(string sequence, int frame)
        {
            var url = "dna/translate";
            var body = new BodyTranslateDto { Sequence = sequence, Frame = frame };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> GetReverseComplement(string sequence, bool reverse, bool complement)
        {
            var url = "dna/reverse_complement";
            var body = new BodyReverseComplementDto { Sequence = sequence, Reverse = reverse, Complement = complement };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
        public async Task<byte[]> GetAlignProtein(byte[] prediction_pdb, byte[] reference_pdb)
        {
            var url = "pdb/align";
            //var body = new BodyAlignPdbDto { PredictionPdb = prediction_pdb, ReferencePdb = reference_pdb }; ///enviar byte[]
            var body = new
            {
                prediction_pdb = Convert.ToBase64String(prediction_pdb),
                reference_pdb = Convert.ToBase64String(reference_pdb)
            };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json"); 
            var response = await _httpClient.PostAsync(url, content);
            var result = await response.Content.ReadAsByteArrayAsync();
            return result;
        }
    }
}
