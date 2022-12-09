using System.Net;

namespace shop_app.api.Exceptions
{
    public class NotFoundException : RequestExceptionBase
    {
        public NotFoundException(string? message, Exception? innerException)
            : base((int)HttpStatusCode.NotFound, message, innerException)
        {
        }
    }
}
