using MediatR;
using shop_app.entity;
using shop_app.shared.Utilities.Results.Abstract;

namespace shop_app.api.Requests.Abstract
{
    public class GetProductQuery: IRequest<IDataResult<Product>>
    {
        public Guid Id { get; set; }
        public GetProductQuery(Guid id)
        {
            Id = id;
        }
    }
}
