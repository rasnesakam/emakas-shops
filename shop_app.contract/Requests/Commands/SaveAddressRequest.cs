using MediatR;
using shop_app.contract.Dto;
using shop_app.contract.ServiceResults;

namespace shop_app.contract.Requests.Commands;

public class SaveAddressRequest: IRequest<ServiceResult<AddressDto>>
{
    public AddressDto Address { get; set; }
}