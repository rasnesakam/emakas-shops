using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.ServiceResults;

namespace shop_app.contract.Requests.Queries;

public class GetAllCategoriesRequest : IRequest<ServiceResult<IEnumerable<CategoryDto>>>
{
    public int? Page { get; set; }
    public int? Size { get; set; }

}
