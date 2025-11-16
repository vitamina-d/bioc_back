using Application;
using Application.DTO.Blast;
using Application.DTO.Folding;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Infrastructure.Query
{
    public class PublicApiClient : BaseClient, IPublicApiClient
    {
        private readonly IConfiguration _configuration;

        public PublicApiClient(HttpClient httpClient, IConfiguration configuration) : base(httpClient)
        {
            _configuration = configuration;
        }
        //GET
        public async Task<string> GetNcbiResponse(string entrez, string type)
        {
            var _ncbiURL = _configuration["API_URL:NCBI"]; 
            string url = $"{_ncbiURL}entrez/eutils/esummary.fcgi?db={type}&id={entrez}&retmode=json";

            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);
            return response;
        }

        //BYTE
        public async Task<byte[]> DownloadPdb(string pdbId)
        {
            var _rcsbURL = _configuration["API_URL:RCSB"];
            var url = $"{_rcsbURL}download/{pdbId}.pdb";
            var response = await HandlerTryCatch<byte[]>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);
            return response;
        }

        public async Task<string?> GetAlphaFoldId(string accession)
        {
            var url = "https://search.rcsb.org/rcsbsearch/v2/query?json";
            //ruta completa
            var payload = new
            {
                query = new
                {
                    type = "group",
                    logical_operator = "and",
                    nodes = new object[]
            {
                new {
                    type = "group",
                    logical_operator = "and",
                    nodes = new object[]
                    {
                        new {
                            type = "group",
                            logical_operator = "and",
                            nodes = new object[]
                            {
                                new {
                                    type = "terminal",
                                    service = "full_text",
                                    parameters = new {
                                        value = accession
                                    }
                                }
                            }
                        }
                    }
                }
            }
                },
                return_type = "entry",
                request_options = new
                {
                    results_content_type = new[] { "computational", "experimental" },
                    paginate = new { start = 0, rows = 25 },
                    sort = new[] { new { sort_by = "score", direction = "desc" } },
                    scoring_strategy = "combined"
                }
            };
            //rcsb_polymer_entity_container_identifiers.reference_sequence_identifiers.database_accession

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.PostAsync(url, content);
            }, url);
            var result = JsonSerializer.Deserialize<AlphaFoldResponseDto>(response);

            return result.ResultSet[0].Identifier;// "AF_AF Q7SXF1 F1" AF-accession-F1
            ;
        }

        public async Task<byte[]> DownloadModel(string accession)
        {
            //var url = $"https://www.rcsb.org/3d-view/{alphafoldId}/deposited";
            // model server api https://models.rcsb.org/
            //var url = $"https://models.rcsb.org/v1/{alphafoldId}/full?encoding=cif";
            //var url = "https://alphafold.ebi.ac.uk/entry/Q7SXF1";
            var _AFURL = _configuration["API_URL:ALPHAFOLD"];
            var url = $"{_AFURL}files/AF-{accession}-F1-model_v6.pdb";
            //var result = await _httpClient.GetByteArrayAsync(url);
            //return result;

            var response = await HandlerTryCatch<byte[]>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);
            return response;
        }
        public async Task<string> DownloadpLDDT(string accession)
        {
            var _AFURL = _configuration["API_URL:ALPHAFOLD"];
            //var url = $"{_AFURL}files/AF-{accession}-F1-predicted_aligned_error_v6.json";
            var url = $"{_AFURL}files/AF-{accession}-F1-confidence_v6.json"; 
            //https://alphafold.ebi.ac.uk/files/AF-Q7SXF1-F1-predicted_aligned_error_v6.json
            //https://alphafold.ebi.ac.uk/files/AF-Q7SXF1-F1-confidence_v6.json
            //return await _httpClient.GetStringAsync(url);

            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);
            return response;
        }
    }
}
