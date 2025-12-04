using Domain.Exceptions;

namespace Infrastructure.Query
{
    public abstract class BaseClient
    {
        protected readonly HttpClient _httpClient;

        protected BaseClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<T> HandlerTryCatch<T>(Func<Task<HttpResponseMessage>> action, string url)
        {
            int code = 0;
            try
            {
                var httpResponse = await action();
                if (httpResponse == null)
                {
                    throw new ClientException(502, $"Respuesta nula desde: {url}");
                }

                code = (int)httpResponse.StatusCode;

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    throw new ClientException(code, content);
                } 

                // string o byte[]
                if (typeof(T) == typeof(string))
                {
                    return (T)(object)await httpResponse.Content.ReadAsStringAsync();
                }
                else if (typeof(T) == typeof(byte[]))
                {
                    return (T)(object)await httpResponse.Content.ReadAsByteArrayAsync();
                }
                else { throw new NotSupportedException($"HandlerTryCatch devuelve -string- o -byte[]-, {typeof(T)} no."); }

            }
            catch (ClientException)
            {
                throw;
            }
            catch (NullReferenceException ex )
            {
                throw new ClientException(504, $"NullReferenceException: {ex.Message}", ex);
            }
            catch (TimeoutException ex)
            {
                throw new ClientException(504, $"TimeoutException: {ex.Message}", ex);
            }
            catch (HttpRequestException ex)
            {
                throw new ClientException(502, $"HttpRequestException {url}: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new ClientException(500, $"Exception: {ex.Message}", ex);
            }
        }
    }

}
