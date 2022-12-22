using MediatR;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests.Queries
{
    public class GetProductsByCategoryRequest: IRequest<ServiceResult<IEnumerable<Product>>>
    {
        public Category Category { get; set; }

        public GetProductsByCategoryRequest(Category category)
        {
            Category = category;
        }
    }
}
