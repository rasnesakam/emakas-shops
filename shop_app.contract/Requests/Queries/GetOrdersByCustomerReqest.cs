using MediatR;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests.Queries
{
    public class GetOrdersByCustomerReqest: IRequest<ServiceResult<IEnumerable<Order>>>
    {
        public Guid UserId { get; set; }

        public GetOrdersByCustomerReqest(Guid userId)
        {
            UserId = userId;
        }

    }
}
