using MediatR;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests.Queries;

public class SearchProductsByName: IRequest<ServiceResult<IEnumerable<Product>>>
{
    public string Name { get; set; }
}