using Domain;
using Domain.DTO.Python;
using Infrastructure.Query;
using System.Text;
using System.Text.Json;

namespace Application
{
    public class PythonClient : BaseClient, IPythonClient
    {
        public PythonClient(HttpClient httpClient) : base(httpClient) { }
        public async Task<string> GetAminoAcidSeq(string sequence, int frame)
        {
            var url = "dna/translate/";
            var body = new BodyTranslateDto { Sequence = sequence, Frame = frame };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.PostAsync(url, content);
            }, url);
            return response;
        }

        public async Task<string> GetReverseComplement(string sequence, bool reverse, bool complement)
        {
            var url = "dna/reverse_complement/";
            var body = new BodyReverseComplementDto { Sequence = sequence, Reverse = reverse, Complement = complement };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.PostAsync(url, content);
            }, url);
            return response;
        }

        public async Task<byte[]> GetAlignProtein(byte[] prediction_pdb, byte[] reference_pdb)
        {
            var url = "pdb/multipart/";
            var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(prediction_pdb), "prediction_pdb", "prediction.pdb");
            content.Add(new ByteArrayContent(reference_pdb), "reference_pdb", "reference.pdb");

            var response = await HandlerTryCatch<byte[]>(async () =>
            {
                return await _httpClient.PostAsync(url, content);
            }, url);
            return response;

        }
    }
}
