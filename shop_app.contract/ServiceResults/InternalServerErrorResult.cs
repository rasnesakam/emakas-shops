using shop_app.contract.HttpExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.ServiceResults
{
    public class InternalServerErrorResult<T> : ServiceResult<T>
    {
        public InternalServerErrorResult(string? message) : base(new InternalServerErrorException(message))
        {
        }
        public InternalServerErrorResult() : base(new InternalServerErrorException(null))
        {
        }
    }
}
