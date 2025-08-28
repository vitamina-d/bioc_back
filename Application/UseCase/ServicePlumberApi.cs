using Application.DTO;
using Application.Interfaces.DTO;
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
        public async Task<ResponsePlumberDto<T?>> GetDetail<T>(string value, bool full) //value es entrez, alias o symbol
        {
            var entrez = await GetEntrezByValue(value);
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

        public async Task<ResponsePlumberDto<DataSequenceDto?>> GetSequence(string value, bool complete) //value es entrez, alias o symbol
        {
            string entrez = await GetEntrezByValue(value);

            var res = await _plumberApiClient.GetSequence(entrez, complete);
            var json = JsonSerializer.Deserialize<ResponsePlumberDto<DataSequenceDto?>>(res);
            json.Data.Entrez = entrez;
            return json;
        }

        //metodo para service
        public async Task<string?> GetEntrezByValue(string value) //value es entrez, alias o symbol
        {
            string entrez;
            var isEntrezResponse = await _plumberApiClient.IsEntrez(value);
            var jsonIsEntrez = JsonSerializer.Deserialize<ResponsePlumberDto<DataIsEntrezDto>>(isEntrezResponse);
            if (jsonIsEntrez.Data != null && jsonIsEntrez.Data.IsEntrez)
            {
                return value;
            }
            else
            {
                var getEntrez = await _plumberApiClient.GetEntrez(value);
                var jsonEntrez = JsonSerializer.Deserialize<ResponsePlumberDto<DataEntrezDto?>>(getEntrez);
                if (jsonEntrez.Data != null)
                {
                    return jsonEntrez.Data.Entrez;
                }
                return null;
            }
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
