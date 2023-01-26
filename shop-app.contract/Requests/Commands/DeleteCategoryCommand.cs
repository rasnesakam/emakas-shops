using MediatR;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests.Commands
{
    public class DeleteCategoryCommand: IRequest<ServiceResult<Category>>
    {
        public string URI { get; set; }
    }
}
