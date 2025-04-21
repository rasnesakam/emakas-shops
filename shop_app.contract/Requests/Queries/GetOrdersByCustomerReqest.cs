using MediatR;
using shop_app.contract.dto;
using shop_app.contract.ServiceResults;
namespace shop_app.contract.Requests.Queries
{
    public class GetOrdersByCustomerReqest: IRequest<ServiceResult<IEnumerable<OrderDto>>>
    {
        public Guid UserId { get; set; }

        public GetOrdersByCustomerReqest(Guid userId)
        {
            UserId = userId;
        }

    }
}
