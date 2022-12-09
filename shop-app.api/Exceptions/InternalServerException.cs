using System.Net;

namespace shop_app.api.Exceptions
{
    public class InternalServerException : RequestExceptionBase
    {
        public InternalServerException(string? message, Exception? innerException) 
            : base((int) HttpStatusCode.InternalServerError, message, innerException)
        {
        }
    }
}
