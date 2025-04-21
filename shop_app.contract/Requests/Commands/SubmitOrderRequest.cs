using MediatR;
using shop_app.contract.dto;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests.Commands
{
    public class SubmitOrderRequest: IRequest<ServiceResult<OrderDto>>
    {
        public OrderDto Order { get; }

        public SubmitOrderRequest(OrderDto order)
        {
            Order = order;
        }
    }
}
