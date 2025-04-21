using MediatR;
using shop_app.contract.dto;
using shop_app.contract.ServiceResults;

namespace shop_app.contract.Requests.Queries
{
    public class GetAllOrdersRequest: IRequest<ServiceResult<IEnumerable<OrderDto>>>
    {
    }
}
