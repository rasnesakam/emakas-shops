using shop_app.shared.Utilities.Results.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus status, string message, Exception exception)
        {
            Status = status;
            Message = message;
            Exception = exception;
        }
        
        public Result(ResultStatus status)
        {
            Status=status;
        }

        public Result(string message)
        {
            Message = message;
        }

        public Result(Exception exception)
        {
            Exception = exception;
        }

        public ResultStatus Status { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
