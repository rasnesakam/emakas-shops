using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.HttpExceptions
{
    public class HttpExceptionBase: Exception
    {
        public int StatusCode { get; set; }

        public HttpExceptionBase(int statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpExceptionBase(string? message) : base(message)
        {
        }

        public HttpExceptionBase(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
