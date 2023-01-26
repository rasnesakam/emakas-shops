using shop_app.contract.HttpExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.ServiceResults
{
    public class BadRequestErrorResult<T> : ServiceResult<T>
    {
        public BadRequestErrorResult(string? message) : base(new BadRequestErrorException(message))
        {
        }
        public BadRequestErrorResult() : base(new BadRequestErrorException(null))
        {
        }
    }
}
