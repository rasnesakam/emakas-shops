using MediatR;
using shop_app.contract.Dto;
using shop_app.contract.ServiceResults;

namespace shop_app.contract.Requests.Commands;

public class SaveCustomerRequest: IRequest<ServiceResult<CustomerDto>>
{
    public CustomerDto Customer;

}