using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.HttpExceptions
{
    public class NotFoundException : HttpExceptionBase
    {
        private static int CODE = 404;
        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException(): base(CODE)
        {
        }

        public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
