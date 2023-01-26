using MediatR;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests.Queries
{
    public class GetAllOrdersRequest: IRequest<ServiceResult<IEnumerable<Order>>>
    {
    }
}
