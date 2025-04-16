using MediatR;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests.Commands;

public class SubmitCategoryRequest: IRequest<ServiceResult<Category>>
{
    public Category Category { get; set; }
}