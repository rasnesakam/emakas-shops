using MediatR;
using shop_app.entity;
using shop_app.shared.Utilities.Results.Abstract;

namespace shop_app.api.Requests.Queries
{
    public class GetOrdersQuery: IRequest<IDataResult<IEnumerable<Order>>>
    {
        public Guid UserId { get; set; }

        public GetOrdersQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
