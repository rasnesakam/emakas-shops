using shop_app.contract.HttpExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.ServiceResults
{
    public class SuccessStatus<T> : ServiceResult<T>
    {
        public SuccessStatus(T value) : base(null, value, true)
        {
        }

    }
}
