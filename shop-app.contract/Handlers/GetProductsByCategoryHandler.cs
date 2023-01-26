using System.Collections;
using MediatR;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class GetProductsByCategoryHandler: IRequestHandler<GetProductsByCategoryRequest, ServiceResult<IEnumerable<Product>>>
{
    private IProductService _service;

    public GetProductsByCategoryHandler(IProductService service)
    {
        _service = service;
    }

    public async Task<ServiceResult<IEnumerable<Product>>> Handle(GetProductsByCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAllByCategory(request.Category);
        return response.Status switch
        {
            ResultStatus.Success => new SuccessStatus<IEnumerable<Product>>(response.Payload),
            ResultStatus.NotFound => new NotFoundErrorResult<IEnumerable<Product>>(),
            _ => new InternalServerErrorResult<IEnumerable<Product>>(response.Message,response.Exception)
        };
    }
}