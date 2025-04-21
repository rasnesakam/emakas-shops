using AutoMapper;
using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.data.Exceptions;
using shop_app.service.Abstract;

namespace shop_app.contract.Handlers
{
    public class GetProductByUriRequestHandler : IRequestHandler<GetProductByUriRequest, ServiceResult<ProductDto>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetProductByUriRequestHandler(IProductService productService, IMapper mapper)
        {
            this._productService = productService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ProductDto>> Handle(GetProductByUriRequest request, CancellationToken cancellationToken)
        {
            var result = await _productService.GetByUri(uri: request.Uri);
            if (result.Status == shared.Utilities.Results.ComplexTypes.ResultStatus.Success)
                return new ServiceResult<ProductDto>(_mapper.Map<ProductDto>(result.Payload));
            if (result.Exception is NoElementFoundException)
                return new NotFoundErrorResult<ProductDto>();
            return new InternalServerErrorResult<ProductDto>();
        }
    }
}
