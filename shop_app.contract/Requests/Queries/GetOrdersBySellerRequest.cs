using MediatR;
using shop_app.contract.dto;
using shop_app.contract.ServiceResults;
namespace shop_app.contract.Requests.Queries;

public class GetOrdersBySellerRequest: IRequest<ServiceResult<IEnumerable<OrderDto>>>
{
    public Guid SellerId { get; set; }
}