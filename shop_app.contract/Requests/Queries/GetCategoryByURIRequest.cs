using MediatR;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests.Queries
{
    public class GetCategoryByURIRequest: IRequest<ServiceResult<Category>>
    {
        public string URI { get; set; }

        public GetCategoryByURIRequest(string uRI)
        {
            URI = uRI;
        }
    }
}
