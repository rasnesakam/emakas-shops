namespace shop_app.api.Exceptions
{
    public class RequestExceptionBase: Exception
    {
        public int StatusCode { get; }

        public RequestExceptionBase(int statusCode, string? message, Exception? innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}
