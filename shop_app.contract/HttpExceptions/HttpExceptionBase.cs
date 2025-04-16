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

        public HttpExceptionBase(string? message, int statusCode) : base(message)
        {
            StatusCode=statusCode;
        }

        public HttpExceptionBase(string? message, Exception? innerException, int statusCode) : base(message, innerException)
        {
            StatusCode = statusCode;
        }


    }
}
