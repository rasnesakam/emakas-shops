using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.HttpExceptions
{
    public class UnauthorizedErrorException : HttpExceptionBase
    { 

        private static readonly int STATUS_CODE = 401;

        public UnauthorizedErrorException() : base(STATUS_CODE)
        {
        }

        public UnauthorizedErrorException(string? message) : base(message, STATUS_CODE)
        {
        }

        public UnauthorizedErrorException(string? message, Exception? innerException) : base(message, innerException, STATUS_CODE)
        {
        }
    }
}
