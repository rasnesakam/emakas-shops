using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.HttpExceptions
{
    public class InternalServerErrorException : HttpExceptionBase
    {
        private static readonly int STATUS_CODE = 500;
        public InternalServerErrorException(string? message) : base(message, STATUS_CODE)
        {
        }

        public InternalServerErrorException(string? message, Exception? innerException) : base(message, innerException, STATUS_CODE)
        {
        }
    }
}
