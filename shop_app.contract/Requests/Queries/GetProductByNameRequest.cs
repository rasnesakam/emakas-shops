using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.ServiceResults;

namespace shop_app.contract.Requests.Queries;

public class GetProductByNameRequest: IRequest<ServiceResult<ProductDto>>
{
    public string Name { get; set; }
}