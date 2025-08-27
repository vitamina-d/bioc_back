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

        public async Task<ResponsePlumberDto<DataAlignDto>> GetAlignment(BodyAlignDto bodyDto)
        {
            var res = await _plumberApiClient.GetAlign(bodyDto.Pattern, bodyDto.Subject, bodyDto.Global);
            var json = JsonSerializer.Deserialize<ResponsePlumberDto<DataAlignDto>> (res);
            return json;
        }

        public async Task<ResponsePlumberDto<DataDetailDto>> GetDetail(string value) //value es entrez, alias o symbol
        {
            //duplicado
            string entrez = await GetEntrezByValue(value);
            //duplicado

            var res = await _plumberApiClient.GetDetail(entrez);
            var json = JsonSerializer.Deserialize<ResponsePlumberDto<DataDetailDto>>(res);
            return json;
        }
        /*
        public async Task<EchoResponseDto> GetMessage(string msg)
        {
            var res = await _plumberApiClient.GetEcho(msg);
            var json = JsonSerializer.Deserialize<EchoResponseDto>(res);
            return json;
        }
        */
        public async Task<ResponsePlumberDto<DataPercentDto>> GetPercent(string sequence)
        {
            var res = await _plumberApiClient.GetPercent(sequence);
            var dto = JsonSerializer.Deserialize<ResponsePlumberDto<DataPercentDto>>(res);
            return dto;
        }

        public async Task<ResponsePlumberDto<DataSequenceDto>> GetSequence(string chrom, int start, int end)
        {
            var res = await _plumberApiClient.GetSequence(chrom, start, end);
            var json = JsonSerializer.Deserialize<ResponsePlumberDto<DataSequenceDto>>(res);
            return json;
        }

        public async Task<ResponsePlumberDto<DataSequenceDto>> GetSequence(string value, bool complete) //value es entrez, alias o symbol
        {
            //duplicado
            string entrez = await GetEntrezByValue(value);
            //duplicado
            var res = await _plumberApiClient.GetSequence(entrez, complete);
            var json = JsonSerializer.Deserialize<ResponsePlumberDto<DataSequenceDto>>(res);
            return json;
        }

        //metodo para service
        public async Task<string> GetEntrezByValue(string value) //value es entrez, alias o symbol
        {
            string entrez;
            var isEntrezResponse = await _plumberApiClient.IsEntrez(value);
            var jsonIsEntrez = JsonSerializer.Deserialize<ResponsePlumberDto<DataIsEntrezDto>>(isEntrezResponse);
            bool isEntrez = jsonIsEntrez.Data.IsEntrez;
            if (isEntrez)
            {
                entrez = value;
            }
            else
            {
                var getEntrez = await _plumberApiClient.GetEntrez(value);
                var jsonEntrez = JsonSerializer.Deserialize<ResponsePlumberDto<DataEntrezDto>>(getEntrez);
                entrez = jsonEntrez.Data.Entrez;
            }
            return entrez;
        }
        public async Task<ResponsePlumberDto<DataTableDto>> GetTable()
        {
            return await _plumberApiClient.GetTable();
        }
    }
}
