using Application;
using Application.DTO.Folding;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

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

        /*
        public async Task<byte[]> DownloadModel(string accession)
        {
            //var url = $"https://www.rcsb.org/3d-view/{alphafoldId}/deposited";
            // model server api https://models.rcsb.org/
            var _AFURL = _configuration["API_URL:ALPHAFOLD"];
            var url = $"{_AFURL}files/AF-{accession}-F1-model_v6.pdb";

            var response = await HandlerTryCatch<byte[]>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);
            return response;
        }*/
        public async Task<byte[]> DownloadEstructure(string url)
        {
            var response = await HandlerTryCatch<byte[]>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);
            return response;
        }
        public async Task<string?> GetUrlEstructure(string accession)
        {
            var UNIPROT = _configuration["API_URL:UNIPROT"];
            var url = $"{UNIPROT}{accession}.json";

            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);

            if (response.Contains("\"messages\""))
            {
                return null; // {"url":"http://rest.uniprot.org/uniprotkb/123","messages":["The 'accession' value has invalid format. It should be a valid UniProtKB accession"]}
            }

            var json = JsonSerializer.Deserialize<UniprotDto>(response);

            //  "features": [{"evidences": [{ "source": "PDB", "id": "2W72"
            string? identifier = null;
            string? urlEstructure = null;
            if (json.Features != null)
            {
                foreach (var feature in json.Features)
                {
                    if (feature.Evidences == null) //null refrence ex
                    {
                        continue;
                    }

                    foreach (var evidence in feature.Evidences)
                    {
                        if (evidence.Source == "PDB")
                        {
                            identifier = evidence.Id;
                            break;
                        }
                    }
                    if (identifier != null)
                    {
                        break;
                    }
                }
                if (identifier != null)
                {
                    var RCSB = _configuration["API_URL:RCSB"];
                    urlEstructure = $"{RCSB}download/{identifier}.pdb";
                }
            }
            //  "uniProtKBCrossReferences": [{"database": "AlphaFoldDB","id": "A0A024R5F7",
            if (urlEstructure == null && json.UniProtKBCrossReferences != null)
            {
                foreach (var reference in json.UniProtKBCrossReferences)
                {
                    if (reference.Database == "AlphaFoldDB")
                    {
                        identifier = reference.Id;
                        break;
                    }
                }
                if (identifier != null)
                {
                    var ALPHAFOLD = _configuration["API_URL:ALPHAFOLD"];
                    urlEstructure = $"{ALPHAFOLD}files/AF-{identifier}-F1-model_v6.pdb";
                }
            }
            return urlEstructure;
        }
        public async Task<string> DownloadpLDDT(string accession)
        {
            //https://alphafold.ebi.ac.uk/files/AF-Q7SXF1-F1-confidence_v6.json
            var ALPHAFOLD = _configuration["API_URL:ALPHAFOLD"];
            var url = $"{ALPHAFOLD}files/AF-{accession}-F1-confidence_v6.json";  //-predicted_aligned_error_v6.json

            var response = await HandlerTryCatch<string>(async () =>
            {
                return await _httpClient.GetAsync(url);
            }, url);
            return response;
        }
    }
}
