using System.Collections;
using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.ServiceResults;
using shop_app.entity;

namespace shop_app.contract.Requests.Commands;

public class SubmitPropertiesRequest:IRequest<ServiceResult<IEnumerable<Property>>>
{
    public Guid ProductId { get; set; }
    public IEnumerable<PropertyDto> PropertyDtos { get; set; }
}