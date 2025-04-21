using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests.Commands;

public class UpdateCategoryRequest: IRequest<ServiceResult<CategoryDto>>
{
    public CategoryDto Category { get; set; }
    public Guid? CategoryId { get; set; }
    public string CategoryUri { get; set; }
    
}