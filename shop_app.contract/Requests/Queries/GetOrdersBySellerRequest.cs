using MediatR;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests;

public class GetOrdersBySellerRequest: IRequest<ServiceResult<IEnumerable<Order>>>
{
    
}