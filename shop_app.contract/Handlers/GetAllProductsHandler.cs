using MediatR;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;
using shop_app.shared.Utilities.Results.Concrete;

namespace shop_app.contract.Handlers;

public class GetAllProductsHandler: IRequestHandler<GetAllProductsRequest,ServiceResult<IEnumerable<Product>>>
{
    private IProductService _service;

    public GetAllProductsHandler(IProductService service)
    {
        _service = service;
    }

    public async Task<ServiceResult<IEnumerable<Product>>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> products;
        IDataResult<IEnumerable<Product>> result;
        if (request.Page != null && request.Size != null)
            result = await _service.GetPart(request.Page.Value * request.Size.Value, request.Size.Value);
        else
            result = await _service.GetAll();
        switch (result.Status)
        {
            case ResultStatus.Success:
                return new SuccessStatus<IEnumerable<Product>>(result.Payload);
            case ResultStatus.NotFound:
                return new NotFoundErrorResult<IEnumerable<Product>>(result.Message);
            default:
                return new InternalServerErrorResult<IEnumerable<Product>>();
        }
    }
}
