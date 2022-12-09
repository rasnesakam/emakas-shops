using System.Net;

namespace shop_app.api.Exceptions
{
    public class BadRequestException : RequestExceptionBase
    {
        public BadRequestException(string? message, Exception? innerException)
            : base((int)HttpStatusCode.BadRequest, message, innerException)
        {
        }

    }
}
