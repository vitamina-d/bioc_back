using Application.DTO;
using Application.DTO.Plumber;
using System.Text.Json;

namespace Application
{
    public class ServicePlumberApi : IServicePlumberApi
    {
        private readonly IPlumberApiClient _plumberApiClient;

        public ServicePlumberApi(IPlumberApiClient plumberApiClient)
        {
            _plumberApiClient = plumberApiClient;
        }
        public async Task<ResponseDto<string[]>> GetAutoComplete(string input)
        {
            var res = await _plumberApiClient.GetAutoComplete(input);
            var json = JsonSerializer.Deserialize<ResponseDto<string[]?>> (res);
            return json;
        }
        public async Task<ResponseDto<DataDetailDto?>> GetDetail(string entrez)
        {
            var isFull = false;
            var response = await _plumberApiClient.GetDetail(entrez, isFull);
            var json = JsonSerializer.Deserialize<ResponseDto<DataDetailDto?>>(response);
            return json;
        }
        public async Task<ResponseDto<DataFullDetailDto?>> GetFullDetail(string entrez)
        {
            var isFull = true;
            var response = await _plumberApiClient.GetDetail(entrez, isFull);
            var json = JsonSerializer.Deserialize<ResponseDto<DataFullDetailDto?>>(response);
            return json;
        }
        public async Task<ResponseDto<DataAlignDto?>> GetAlignment(string pattern, string subject, string type, int gapOpening, int gapExtension)
        {
            //pattern, subject, type, match, mismatch, gapOpening, gapExtension)
            var res = await _plumberApiClient.GetAlign(pattern, subject, type, gapOpening, gapExtension);
            var json = JsonSerializer.Deserialize<ResponseDto<DataAlignDto?>>(res); 
            return json;
        }

        public async Task<ResponseDto<DataPercentDto?>> GetPercent(string sequence)
        {
            var res = await _plumberApiClient.GetPercent(sequence);
            var dto = JsonSerializer.Deserialize<ResponseDto<DataPercentDto?>>(res);
            return dto;
        }

        public async Task<ResponseDto<DataSequenceDto?>> GetSequence(string chrom, int start, int end)
        {
            var res = await _plumberApiClient.GetSequence(chrom, start, end);
            var json = JsonSerializer.Deserialize<ResponseDto<DataSequenceDto?>>(res);
            return json;
        }

        public async Task<ResponseDto<DataSequenceDto?>> GetSequence(string entrez, bool complete)
        {
            var res = await _plumberApiClient.GetSequence(entrez, complete);
            var json = JsonSerializer.Deserialize<ResponseDto<DataSequenceDto?>>(res);
            json.Data.Entrez = entrez;
            return json;
        }
        public async Task<ResponseDto<DataStatsDto?>> GetStats(string entrez, bool complete)
        {
            var res = await _plumberApiClient.GetStats(entrez, complete);
            var json = JsonSerializer.Deserialize<ResponseDto<DataStatsDto?>>(res);
            return json;
        }
        public async Task<ResponseDto<DataEntrezDto>> GetEntrezByValue(string value) //value es entrez, alias o symbol
        {
            var isEntrezResponse = await _plumberApiClient.IsEntrez(value.ToUpper());
            var jsonIsEntrez = JsonSerializer.Deserialize<ResponseDto<DataIsEntrezDto>>(isEntrezResponse);
            if (jsonIsEntrez.Data != null && jsonIsEntrez.Data.IsEntrez)
            {
                return new ResponseDto<DataEntrezDto>
                {
                    Code = jsonIsEntrez.Code,
                    Message = jsonIsEntrez.Message,
                    Data = new DataEntrezDto { Entrez = value }
                };
            }
            else
            {
                var getEntrez = await _plumberApiClient.GetEntrez(value);
                var jsonEntrez = JsonSerializer.Deserialize<ResponseDto<DataEntrezDto?>>(getEntrez);
                if (jsonEntrez.Data != null)
                {
                    return jsonEntrez;
                }
                return null;
            }
        }
    }
}
