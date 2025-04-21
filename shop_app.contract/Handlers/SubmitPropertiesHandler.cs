using System.Collections;
using MediatR;
using shop_app.contract.Requests.Commands;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class SubmitPropertiesHandler: IRequestHandler<SubmitPropertiesRequest, ServiceResult<IEnumerable<Property>>>
{
    private IPropertyService _service;

    public SubmitPropertiesHandler(IPropertyService service)
    {
        _service = service;
    }

    public async Task<ServiceResult<IEnumerable<Property>>> Handle(SubmitPropertiesRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Property> productProps = request.PropertyDtos.Select(props => new Property()
        {
            ProductId = request.ProductId,
            Key = props.Key,
            Value = props.Value
        }).ToList();
        var response = await _service.CreateBatch(productProps,cancellationToken);
        return response.Status switch
        {
            ResultStatus.Success => new SuccessStatus<IEnumerable<Property>>(productProps),
            _=> new InternalServerErrorResult<IEnumerable<Property>>(response.Message, response.Exception)
        };
    }
}