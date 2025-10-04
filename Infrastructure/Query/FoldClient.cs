using Application.DTO;

namespace Application
{
    public class FoldClient : IFoldClient
    {
        private readonly HttpClient _httpClient;

        public FoldClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public DataPdbDto GetEstructures(string sequence)
        {
            return new DataPdbDto
            {
                Sequence = "dhcr7"
            };
        }
    }
}
