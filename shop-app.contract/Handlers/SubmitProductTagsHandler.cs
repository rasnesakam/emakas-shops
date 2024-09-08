using MediatR;
using shop_app.contract.Requests.Commands;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class SubmitProductTagsHandler: IRequestHandler<SubmitProductTagsRequest, ServiceResult<IEnumerable<ProductTag>>>
{
    private readonly IProductTagService _service;

    public SubmitProductTagsHandler(IProductTagService service)
    {
        _service = service;
    }

    public async Task<ServiceResult<IEnumerable<ProductTag>>> Handle(SubmitProductTagsRequest request, CancellationToken cancellationToken)
    {
        var tags = request.ProductTagDtos.Select(tags => new ProductTag()
        {
            ProductId = request.ProductId,
            Tag = tags.tag
        });
        var response = await _service.CreateBatch(tags, cancellationToken);
        return response.Status switch
        {
            ResultStatus.Success => new SuccessStatus<IEnumerable<ProductTag>>(tags),
            _ => new InternalServerErrorResult<IEnumerable<ProductTag>>(response.Exception)
        };
    }
}