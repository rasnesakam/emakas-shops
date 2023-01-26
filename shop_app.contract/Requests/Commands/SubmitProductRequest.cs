using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests.Commands;

public class SubmitProductRequest: IRequest<ServiceResult<Product>>
{
    public Product Product { get; set; }
}