using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.ServiceResults;

namespace shop_app.contract.Requests.Queries
{
    public class GetProductByUriRequest: IRequest<ServiceResult<ProductDto>>
    {
        public string Uri { get; set; }
    }
}
