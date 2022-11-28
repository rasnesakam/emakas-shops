using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.data.Exceptions
{
    public class NoElementFoundException : Exception
    {
        public NoElementFoundException()
        {
        }

        public NoElementFoundException(string? message) : base(message)
        {
        }

    }
}
