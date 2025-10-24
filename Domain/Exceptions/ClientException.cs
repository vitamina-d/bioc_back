namespace Domain.Exceptions
{
    public class ClientException : Exception
    {
        public int Code { get; }

        public ClientException(int code, string message, Exception? inner = null)
            : base(message, inner)
        {
            Code = code;
        }
    }
}
