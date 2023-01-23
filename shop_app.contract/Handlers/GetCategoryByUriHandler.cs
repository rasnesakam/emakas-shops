using MediatR;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class GetCategoryByUriHandler: IRequestHandler<GetCategoryByURIRequest, ServiceResult<Category>>
{
    private ICategoryService _service;

    public GetCategoryByUriHandler(ICategoryService service)
    {
        _service = service;
    }

    public async Task<ServiceResult<Category>> Handle(GetCategoryByURIRequest request, CancellationToken cancellationToken)
    {
        var result = await _service.GetCagetoryByURI(request.Uri);
        switch (result.Status)
        {
            case ResultStatus.Success:
                return new SuccessStatus<Category>(result.Payload);
            case ResultStatus.NotFound:
                return new NotFoundErrorResult<Category>();
            default:
                return new InternalServerErrorResult<Category>(result.Exception);
        }
    }
}