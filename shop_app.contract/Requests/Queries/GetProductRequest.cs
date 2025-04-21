using MediatR;
using shop_app.contract.ServiceResults;
using shop_app.contract.DTO;

namespace shop_app.contract.Requests.Queries
{
    public class GetProductRequest: IRequest<ServiceResult<ProductDto>>
    {
        public Guid ProductId { get; set; }

        public GetProductRequest(Guid productId)
        {
            ProductId = productId;
        }
    }
}
