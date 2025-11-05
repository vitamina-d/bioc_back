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
                if (!httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    code = (int)httpResponse.StatusCode;
                    throw new ClientException((int)httpResponse.StatusCode, content);
                } else
                {
                    code = (int)httpResponse.StatusCode;
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
                //throw new ClientException(code, $"Timeout: {ex.Message}", ex);
                throw;
            }
            catch (NullReferenceException ex )
            {
                throw new ClientException(504, $"Timeout: {ex.Message}", ex);
            }
            catch (TimeoutException ex)
            {
                throw new ClientException(504, $"Timeout: {ex.Message}", ex);
            }
            catch (HttpRequestException ex)
            {
                throw new ClientException(502, $"Error HTTP {url}: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new ClientException(500, $"Error inesperado: {ex.Message}", ex);
            }
        }
    }

}
