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

        protected async Task<T> HandlerTryCatch<T>(Func<Task<T>> action, string url)
        {
            try
            {
                return await action();
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
