using MediatR;
using shop_app.api.Requests.Abstract;
using shop_app.data.Abstract;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;

namespace shop_app.api.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, IDataResult<Product>>
    {
        private readonly IProductService _productService;

        public GetProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IDataResult<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetOne(request.Id);
        }
    }
}
