using shop_app.shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus Status { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
