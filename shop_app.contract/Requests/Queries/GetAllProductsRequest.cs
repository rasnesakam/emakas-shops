
using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.ServiceResults;

namespace shop_app.contract.Requests.Queries
{
    public class GetAllProductsRequest: IRequest<ServiceResult<IEnumerable<ProductDto>>>
    {
        public int? Size { get; set; }
        public int? Page { get; set; }
    }
}
