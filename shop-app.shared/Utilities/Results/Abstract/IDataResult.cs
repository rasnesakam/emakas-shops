using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.shared.Utilities.Results.Abstract
{
    public interface IDataResult<E> : IResult
    {
        public E Payload { get; }
    }
}
