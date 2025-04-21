using AutoMapper;
using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;
using shop_app.shared.Utilities.Results.Concrete;

namespace shop_app.contract.Handlers;

public class GetAllProductsHandler: IRequestHandler<GetAllProductsRequest,ServiceResult<IEnumerable<ProductDto>>>
{
    private IProductService _service;
    private IMapper _mapper;

    public GetAllProductsHandler(IProductService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<ServiceResult<IEnumerable<ProductDto>>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> products;
        IDataResult<IEnumerable<Product>> result;
        if (request.Page != null && request.Size != null)
            result = await _service.GetPart(request.Page.Value * request.Size.Value, request.Size.Value);
        else
            result = await _service.GetAll();
        switch (result.Status)
        {
            case ResultStatus.Success:
                return new SuccessStatus<IEnumerable<ProductDto>>(result.Payload.Select(p => _mapper.Map<ProductDto>(p)));
            case ResultStatus.NotFound:
                return new NotFoundErrorResult<IEnumerable<ProductDto>>(result.Message);
            default:
                return new InternalServerErrorResult<IEnumerable<ProductDto>>();
        }
    }
}
