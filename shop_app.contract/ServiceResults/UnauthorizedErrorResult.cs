using shop_app.contract.HttpExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.ServiceResults
{
    public class UnauthorizedErrorResult<T> : ServiceResult<T>
    {
        public UnauthorizedErrorResult(string? message) : base(new UnauthorizedErrorException(message))
        {
        }
        public UnauthorizedErrorResult() : base(new UnauthorizedErrorException(null))
        {
        }
    }
}
