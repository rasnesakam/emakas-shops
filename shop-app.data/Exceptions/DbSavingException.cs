using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.data.Exceptions
{
    public class DbSavingException : Exception
    {
        public DbSavingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
