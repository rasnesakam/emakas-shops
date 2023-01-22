using MediatR;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests.Queries;

public class GetAllCategoriesRequest : IRequest<ServiceResult<IEnumerable<Category>>>
{
    public int? Page { get; set; }
    public int? Size { get; set; }

}
