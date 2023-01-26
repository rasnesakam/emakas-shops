using MediatR;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests.Commands
{
    public class SubmitOrderRequest: IRequest<ServiceResult<Order>>
    {
        public Order Order { get; }

        public SubmitOrderRequest(Order order)
        {
            Order = order;
        }
    }
}
