using Application.DTO;

namespace Application
{
    public class PyClient : IPyClient
    {
        private readonly HttpClient _httpClient;

        public PyClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public DataAADto GetAASeq(string sequence, string frame)
        {
            throw new NotImplementedException();
        }

        public DataPdbDto[] GetPdbs(DataPdbDto prediction, string pbdId)
        {
            throw new NotImplementedException();
        }
    }
}
