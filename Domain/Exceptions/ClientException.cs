namespace Domain.Exceptions
{
    public class ClientException(int code, string message, Exception? inner = null) : Exception(message, inner)
    {
        public int Code { get; } = code;
    }
}
