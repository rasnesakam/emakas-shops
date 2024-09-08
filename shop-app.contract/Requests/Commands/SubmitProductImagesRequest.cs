using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests.Commands;

public class SubmitProductImagesRequest: IRequest<ServiceResult<IEnumerable<ProductImage>>>
{
    public IEnumerable<ProductImageDto> ProductImageDtos { get; set; }
    public Guid ProductId { get; set; }
}