using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests.Commands;

public class SubmitProductTagsRequest: IRequest<ServiceResult<IEnumerable<ProductTag>>>
{
    public Guid ProductId { get; set; }
    public IEnumerable<ProductTagDto> ProductTagDtos { get; set; }
}