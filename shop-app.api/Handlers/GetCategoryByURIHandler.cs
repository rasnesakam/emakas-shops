using MediatR;
using shop_app.api.Requests.Queries;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;

namespace shop_app.api.Handlers
{
    public class GetCategoryByURIHandler : IRequestHandler<GetCategoryByURIQuery, IDataResult<Category>>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoryByURIHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public Task<IDataResult<Category>> Handle(GetCategoryByURIQuery request, CancellationToken cancellationToken)
        {
            return _categoryService.GetCagetoryByURI(request.URI);
        }
    }
}
