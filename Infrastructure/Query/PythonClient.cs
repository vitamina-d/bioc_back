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
            var url = "dna/translate/";
            var body = new BodyTranslateDto { Sequence = sequence, Frame = frame };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            try
            {
                var response = await _httpClient.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }

            catch (HttpRequestException ex)
            {
                throw new Exception($"Error HTTP {url}: {ex.Message}", ex);
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"Timeout: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado: {ex.Message}", ex);
            }
        }

        public async Task<string> GetReverseComplement(string sequence, bool reverse, bool complement)
        {
            var url = "dna/reverse_complement/";
            var body = new BodyReverseComplementDto { Sequence = sequence, Reverse = reverse, Complement = complement };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }

            catch (HttpRequestException ex)
            {
                throw new Exception($"Error HTTP {url}: {ex.Message}", ex);
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"Timeout: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado: {ex.Message}", ex);
            }
        }

        public async Task<byte[]> GetAlignProtein(byte[] prediction_pdb, byte[] reference_pdb)
        {
            var url = "pdb/multipart/";
            var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(prediction_pdb), "prediction_pdb", "prediction.pdb");
            content.Add(new ByteArrayContent(reference_pdb), "reference_pdb", "reference.pdb");

            try
            {
                var response = await _httpClient.PostAsync(url, content);
                var contentType = response.Content.Headers.ContentType;
                var result = await response.Content.ReadAsByteArrayAsync();

                return result;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error HTTP {url}: {ex.Message}", ex);
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"Timeout: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado: {ex.Message}", ex);
            }

        }
    }
}
