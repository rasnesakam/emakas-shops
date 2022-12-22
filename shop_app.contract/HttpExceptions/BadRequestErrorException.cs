using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.HttpExceptions
{
    public class BadRequestErrorException : HttpExceptionBase
    {
        private static readonly int STATUS_CODE = 403;
        public BadRequestErrorException() : base(STATUS_CODE)
        {
        }

        public BadRequestErrorException(string? message) : base(message, STATUS_CODE)
        {
        }

        public BadRequestErrorException(string? message, Exception? innerException) : base(message, innerException, STATUS_CODE)
        {
        }
    }
}
