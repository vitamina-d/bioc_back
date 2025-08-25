﻿using Application.DTO;
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

        public async Task<AlignResponseDto> GetAlignment(AlignBodyDto bodyDto)
        {
            var res = await _plumberApiClient.GetAlign(bodyDto.Pattern, bodyDto.Subject, bodyDto.Global);
            var json = JsonSerializer.Deserialize<AlignResponseDto>(res);
            return json;
        }

        public async Task<DetailResponseDto> GetDetail(string value) //value es entrez, alias o symbol
        {
            //duplicado
            string entrez = await GetEntrezByValue(value);
            //duplicado

            var res = await _plumberApiClient.GetDetail(entrez);
            var json = JsonSerializer.Deserialize<DetailResponseDto>(res);
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
        public async Task<PercentResponseDto> GetPercent(string sequence)
        {
            var res = await _plumberApiClient.GetPercent(sequence);
            var dto = JsonSerializer.Deserialize<PercentResponseDto>(res);
            return dto;
        }

        public async Task<SeqByRangeResponseDto> GetSequence(string chrom, int start, int end)
        {
            var res = await _plumberApiClient.GetSequence(chrom, start, end);
            var json = JsonSerializer.Deserialize<SeqByRangeResponseDto>(res);
            return json;
        }

        public async Task<SeqBySymbolResponseDto> GetSequence(string value, bool complete) //value es entrez, alias o symbol
        {
            //duplicado
            string entrez = await GetEntrezByValue(value);
            //duplicado
            var res = await _plumberApiClient.GetSequence(entrez, complete);
            var json = JsonSerializer.Deserialize<SeqBySymbolResponseDto>(res);
            return json;
        }

        //metodo para service
        public async Task<string> GetEntrezByValue(string value) //value es entrez, alias o symbol
        {
            string entrez;
            var isEntrezResponse = await _plumberApiClient.IsEntrez(value);
            var jsonIsEntrez = JsonSerializer.Deserialize<IsEntrezResponseDto>(isEntrezResponse);
            bool isEntrez = jsonIsEntrez.Data.IsEntrez;
            if (isEntrez)
            {
                entrez = value;
            }
            else
            {
                var getEntrez = await _plumberApiClient.GetEntrez(value);
                var jsonEntrez = JsonSerializer.Deserialize<EntrezResponseDto>(getEntrez);
                entrez = jsonEntrez.Data.Entrez;
            }
            return entrez;
        }
        public async Task<PlumberResponseDto<DataTableDto>> GetTable()
        {
            return await _plumberApiClient.GetTable();
        }
    }
}
