using MediatR;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests.Queries
{
    public class GetOrdersByUserReqest: IRequest<ServiceResult<IEnumerable<Order>>>
    {
        public Guid UserId { get; set; }

        public GetOrdersByUserReqest(Guid userId)
        {
            UserId = userId;
        }

    }
}
