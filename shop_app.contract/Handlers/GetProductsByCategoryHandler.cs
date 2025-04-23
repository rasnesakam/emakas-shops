using System.Collections;
using AutoMapper;
using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class GetProductsByCategoryHandler: IRequestHandler<GetProductsByCategoryRequest, ServiceResult<IEnumerable<ProductDto>>>
{
    private readonly IProductService _service;
    private readonly IMapper _mapper;

    public GetProductsByCategoryHandler(IProductService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<ServiceResult<IEnumerable<ProductDto>>> Handle(GetProductsByCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAllByCategory(request.Category.Uri);
        return response.Status switch
        {
            ResultStatus.Success => new SuccessStatus<IEnumerable<ProductDto>>(response.Payload.Select(p => _mapper.Map<ProductDto>(p))),
            ResultStatus.NotFound => new NotFoundErrorResult<IEnumerable<ProductDto>>(),
            _ => new InternalServerErrorResult<IEnumerable<ProductDto>>(response.Message,response.Exception)
        };
    }
}