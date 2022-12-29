using shop_app.contract.HttpExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.ServiceResults;

public class ServiceResult<T>
{
    public HttpExceptionBase? Exception { get; set; }
    public T? Value { get; set; }
    public bool Succeed { get; set; }

    public ServiceResult(T value)
    {
        Value = value;

    }

    public ServiceResult(HttpExceptionBase? exception)
    {
        Exception = exception;
    }
}
