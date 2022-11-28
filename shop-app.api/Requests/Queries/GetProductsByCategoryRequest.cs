using MediatR;
using shop_app.entity;
using shop_app.shared.Utilities.Results.Abstract;

namespace shop_app.api.Requests.Queries
{
    public class GetProductsByCategoryRequest: IRequest<IDataResult<IEnumerable<Product>>>
    {
        public Category Category { get; set; }

        public GetProductsByCategoryRequest(Category category)
        {
            Category = category;
        }
    }
}
