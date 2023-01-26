using shop_app.contract.HttpExceptions;
using shop_app.data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.ServiceResults
{
    public class NotFoundErrorResult<T> : ServiceResult<T>
    {
        public NotFoundErrorResult(string? message) : base(new NotFoundErrorException(message))
        {
        }
        public NotFoundErrorResult() : base(new NotFoundErrorException(null))
        {
        }
        public NotFoundErrorResult(NoElementFoundException exception): base(new NotFoundErrorException(exception.Message, exception))
        {

        }
    }
}
