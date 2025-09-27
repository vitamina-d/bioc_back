using Application.DTO;
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

        public async Task<ResponsePlumberDto<DataAlignDto?>> GetAlignment(BodyAlignDto bodyDto)
        {
            //pattern, subject, type, match, mismatch, gapOpening, gapExtension)
            var res = await _plumberApiClient.GetAlign(bodyDto);
            var json = JsonSerializer.Deserialize<ResponsePlumberDto<DataAlignDto?>> (res);
            return json;
        }
        public async Task<ResponsePlumberDto<DataComplementDto?>> GetComplement(BodyComplementDto bodyDto)
        {
            var data = await _plumberApiClient.GetComplement(bodyDto);
            return data;
        }
        public async Task<ResponsePlumberDto<T?>> GetDetail<T>(string entrez, bool full) 
        {
            var response = await _plumberApiClient.GetDetail(entrez, full);
            var json = JsonSerializer.Deserialize<ResponsePlumberDto<T?>>(response);
            return json;
        }

        public async Task<EchoResponseDto> GetMessage(string msg)
        {
            var res = await _plumberApiClient.GetEcho(msg);
            var json = JsonSerializer.Deserialize<EchoResponseDto>(res);
            return json;
        }

        public async Task<ResponsePlumberDto<DataPercentDto?>> GetPercent(string sequence)
        {
            var res = await _plumberApiClient.GetPercent(sequence);
            var dto = JsonSerializer.Deserialize<ResponsePlumberDto<DataPercentDto?>>(res);
            return dto;
        }

        public async Task<ResponsePlumberDto<DataSequenceDto?>> GetSequence(string chrom, int start, int end)
        {
            var res = await _plumberApiClient.GetSequence(chrom, start, end);
            var json = JsonSerializer.Deserialize<ResponsePlumberDto<DataSequenceDto?>>(res);
            return json;
        }

        public async Task<ResponsePlumberDto<DataSequenceDto?>> GetSequence(string entrez, bool complete) 
        {
            var res = await _plumberApiClient.GetSequence(entrez, complete);
            var json = JsonSerializer.Deserialize<ResponsePlumberDto<DataSequenceDto?>>(res);
            json.Data.Entrez = entrez;
            return json;
        }
        public async Task<ResponsePlumberDto<DataStatsDto?>> GetStats(string entrez, bool complete)
        {
            var res = await _plumberApiClient.GetStats(entrez, complete);
            var json = JsonSerializer.Deserialize<ResponsePlumberDto<DataStatsDto?>>(res);
            return json;
        }
        public async Task<ResponsePlumberDto<DataEntrezDto>> GetEntrezByValue(string value) //value es entrez, alias o symbol
        {
            string entrez;
            var isEntrezResponse = await _plumberApiClient.IsEntrez(value.ToUpper());
            var jsonIsEntrez = JsonSerializer.Deserialize<ResponsePlumberDto<DataIsEntrezDto>>(isEntrezResponse);
            if (jsonIsEntrez.Data != null && jsonIsEntrez.Data.IsEntrez)
            {
                return new ResponsePlumberDto<DataEntrezDto>
                {
                    Code = jsonIsEntrez.Code,
                    DateTime = jsonIsEntrez.DateTime,
                    Message = jsonIsEntrez.Message,
                    Time = jsonIsEntrez.Time,
                    Data = new DataEntrezDto { Entrez = value}
                };
            }
            else
            {
                var getEntrez = await _plumberApiClient.GetEntrez(value);
                var jsonEntrez = JsonSerializer.Deserialize<ResponsePlumberDto<DataEntrezDto?>>(getEntrez);
                if (jsonEntrez.Data != null)
                {
                    return jsonEntrez;
                }
                return null;
            }
        }
        public async Task<ResponsePlumberDto<List<string>>> GetAutoComplete(string input)
        {
            var res = await _plumberApiClient.GetAutoComplete(input);
            var json = JsonSerializer.Deserialize<ResponsePlumberDto<List<string>>>(res);
            return json;
        }
        public async Task<ResponsePlumberDto<DataTableDto>> GetTable()
        {
            return await _plumberApiClient.GetTable();
        }

        public async Task<ResponsePlumberDto<DataTableDto>> GetGenenames()
        {
            return await _plumberApiClient.GetGenenames();
        }
    }
}
