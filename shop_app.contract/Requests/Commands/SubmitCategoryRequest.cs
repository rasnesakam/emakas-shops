using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.ServiceResults;

namespace shop_app.contract.Requests.Commands;

public class SubmitCategoryRequest: IRequest<ServiceResult<CategoryDto>>
{
    public CategoryDto Category { get; set; }
}