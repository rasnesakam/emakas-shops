using MediatR;
using shop_app.contract.Requests.Commands;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class SubmitProductHandler: IRequestHandler<SubmitProductRequest, ServiceResult<Product>>
{
    private IProductService _service;

    public SubmitProductHandler(IProductService service)
    {
        _service = service;
    }

    public async Task<ServiceResult<Product>> Handle(SubmitProductRequest request, CancellationToken cancellationToken)
    {
        var response = await _service.Create(request.Product);
        return response.Status switch
        {
            ResultStatus.Success => new SuccessStatus<Product>(request.Product),
            _ => new InternalServerErrorResult<Product>(response.Message, response.Exception)
        };
    }
}