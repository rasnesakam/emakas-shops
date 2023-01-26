using MediatR;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers
{
    public class GetProductRequestHandler : IRequestHandler<GetProductRequest, ServiceResult<Product>>
    {
        private readonly IProductService _productService;

        public GetProductRequestHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ServiceResult<Product>> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var result = await _productService.GetOne(request.ProductId);
            if (result.Status == ResultStatus.Success)
                return new SuccessStatus<Product>(result.Payload);
            return new NotFoundErrorResult<Product>();
        }
    }
}
