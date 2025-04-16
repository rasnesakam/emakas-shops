using shop_app.shared.Utilities.Results.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.shared.Utilities.Results.Concrete
{
    public class DataResult<E> : Result, IDataResult<E>
    {
        public DataResult(ResultStatus status) : base(status)
        {
        }

        public DataResult(string message) : base(message)
        {
        }

        public DataResult(Exception exception) : base(exception)
        {
        }

        public DataResult(ResultStatus status, string message, Exception exception) : base(status, message, exception)
        {
        }

        public DataResult(E data): base(ResultStatus.Success)
        {
            Payload = data;
        }

        public E Payload { get; }
    }
}
