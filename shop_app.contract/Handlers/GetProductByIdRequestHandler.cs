using AutoMapper;
using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers
{
    public class GetProductByIdRequestHandler : IRequestHandler<GetProductRequest, ServiceResult<ProductDto>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetProductByIdRequestHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ProductDto>> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var result = await _productService.GetOne(request.ProductId);
            if (result.Status == ResultStatus.Success)
                return new SuccessStatus<ProductDto>(_mapper.Map<ProductDto>(result.Payload));
            return new NotFoundErrorResult<ProductDto>();
        }
    }
}
