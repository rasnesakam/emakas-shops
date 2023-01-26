using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.HttpExceptions
{
    public class NotFoundErrorException : HttpExceptionBase
    {
        private static readonly int STATUS_CODE = 404;
        public NotFoundErrorException(string? message) : base(message,STATUS_CODE)
        {

        }

        public NotFoundErrorException(): base(STATUS_CODE)
        {
        }

        public NotFoundErrorException(string? message, Exception? innerException) : base(message, innerException, STATUS_CODE)
        {
        }
    }
}
