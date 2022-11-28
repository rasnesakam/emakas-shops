using MediatR;
using shop_app.api.Requests.Queries;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;

namespace shop_app.api.Handlers
{
    public class GetProductsByCategoryRequestHandler 
        : IRequestHandler<GetProductsByCategoryRequest, IDataResult<IEnumerable<Product>>>
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public GetProductsByCategoryRequestHandler(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IDataResult<IEnumerable<Product>>> 
            Handle(GetProductsByCategoryRequest request, CancellationToken cancellationToken)
        {
            IDataResult<Category> categoryResult = await _categoryService.GetCagetoryByURI(request.Category.URI);
            return await _productService.GetAllByCategory(request.Category);
        }
    }
}
