using AutoMapper;
using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.Requests.Commands;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class SubmitProductHandler: IRequestHandler<SubmitProductRequest, ServiceResult<ProductDto>>
{
    private readonly IProductService _service;
    private readonly IMapper _mapper;

    public SubmitProductHandler(IProductService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ProductDto>> Handle(SubmitProductRequest request, CancellationToken cancellationToken)
    {
        var response = await _service.Create(_mapper.Map<Product>(request.Product));
        return response.Status switch
        {
            ResultStatus.Success => new SuccessStatus<ProductDto>(request.Product),
            _ => new InternalServerErrorResult<ProductDto>(response.Message, response.Exception)
        };
    }
}