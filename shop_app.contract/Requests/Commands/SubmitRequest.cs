using MediatR;
using shop_app.contract.ServiceResults;

namespace shop_app.contract.Requests.Commands;

public class SubmitRequest<TE>: IRequest<ServiceResult<TE>>
{
    
}