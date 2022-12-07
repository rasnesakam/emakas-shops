using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.shared.Utilities.Results.ComplexTypes
{
    public enum ResultStatus
    {
        Success = 200,
        Error = 500,
        Warning = 2,
        Info = 3
    }
}
