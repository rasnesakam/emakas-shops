using MediatR;
using shop_app.api.Requests.Queries;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;

namespace shop_app.api.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IDataResult<IEnumerable<Product>>>
    {
        private readonly IProductService _productService;

        public GetAllProductsHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IDataResult<IEnumerable<Product>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            if (request.Page == 0 && request.Size == 0)
                return await _productService.GetAll();
            return await _productService.GetPart(request.Page, request.Size);
        }
    }
}
