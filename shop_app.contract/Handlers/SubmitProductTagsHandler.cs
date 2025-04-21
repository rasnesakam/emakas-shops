using AutoMapper;
using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.Requests.Commands;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class SubmitProductTagsHandler: IRequestHandler<SubmitProductTagsRequest, ServiceResult<IEnumerable<ProductTagDto>>>
{
    private readonly IProductTagService _service;
    private readonly IMapper _mapper;

    public SubmitProductTagsHandler(IProductTagService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<ServiceResult<IEnumerable<ProductTagDto>>> Handle(SubmitProductTagsRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<ProductTag> productTags = request.ProductTagDtos.Select(tags => new ProductTag()
        {
            ProductId = request.ProductId,
            Tag = tags.tag
        }).ToList();
        var response = await _service.CreateBatch(productTags, cancellationToken);
        return response.Status switch
        {
            ResultStatus.Success => new SuccessStatus<IEnumerable<ProductTagDto>>(productTags.Select(t => _mapper.Map<ProductTagDto>(t))),
            _ => new InternalServerErrorResult<IEnumerable<ProductTagDto>>(response.Exception)
        };
    }
}