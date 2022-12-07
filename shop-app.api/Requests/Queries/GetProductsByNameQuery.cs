using MediatR;
using shop_app.entity;
using shop_app.shared.Utilities.Results.Abstract;

namespace shop_app.api.Requests.Queries
{
    public class GetProductsByNameQuery: IRequest<IDataResult<Product>>
    {
        public string Name { get; set; }
    }
}
