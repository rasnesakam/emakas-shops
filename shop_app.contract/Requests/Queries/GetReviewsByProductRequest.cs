using MediatR;
using shop_app.contract.ServiceResults;
using shop_app.contract.Dto;

namespace shop_app.contract.Requests.Queries
{
    public class GetReviewsByProductRequest: IRequest<ServiceResult<IEnumerable<ReviewDto>>>
    {
        public string ProductUri { get; set; }
    }
}
