using MediatR;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.data.Abstract;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class GetProductByNameHandler: IRequestHandler<GetProductByNameRequest, ServiceResult<Product>>
{
    private IProductService _service;

    public GetProductByNameHandler(IProductService service)
    {
        _service = service;
    }

    public async Task<ServiceResult<Product>> Handle(GetProductByNameRequest request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAllBy(p => p.Name == request.Name);
        switch (response.Status)
        {
            case ResultStatus.Success:
                return new SuccessStatus<Product>(response.Payload.First());
            case ResultStatus.NotFound:
                return new NotFoundErrorResult<Product>();
            default: return new InternalServerErrorResult<Product>();
        }
    }
}