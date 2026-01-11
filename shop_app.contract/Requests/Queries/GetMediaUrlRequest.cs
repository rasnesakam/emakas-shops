using MediatR;
using shop_app.contract.ServiceResults;

namespace shop_app.contract.Requests.Queries;

public class GetMediaUrlRequest: IRequest<ServiceResult<String>>
{
    public string ObjectKey { get; set; }
}