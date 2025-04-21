using AutoMapper;
using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class GetProductByNameHandler: IRequestHandler<GetProductByNameRequest, ServiceResult<ProductDto>>
{
    private readonly IProductService _service;
    private readonly IMapper _mapper;

    public GetProductByNameHandler(IProductService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ProductDto>> Handle(GetProductByNameRequest request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAllBy(p => p.Name == request.Name);
        switch (response.Status)
        {
            case ResultStatus.Success:
                return new SuccessStatus<ProductDto>(_mapper.Map<ProductDto>(response.Payload.First()));
            case ResultStatus.NotFound:
                return new NotFoundErrorResult<ProductDto>();
            default: return new InternalServerErrorResult<ProductDto>();
        }
    }
}