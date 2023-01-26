using MediatR;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class GetAllCategoriesHandler: IRequestHandler<GetAllCategoriesRequest,ServiceResult<IEnumerable<Category>>>
{
    private ICategoryService _service;

    public GetAllCategoriesHandler(ICategoryService service)
    {
        _service = service;
    }

    public async Task<ServiceResult<IEnumerable<Category>>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        var result = await _service.GetAll();
        switch (result.Status)
        {
            case ResultStatus.Success:
                return new SuccessStatus<IEnumerable<Category>>(result.Payload);
            case ResultStatus.NotFound:
                return new NotFoundErrorResult<IEnumerable<Category>>(result.Message);
            default:
                return new InternalServerErrorResult<IEnumerable<Category>>(result.Message, result.Exception);
        }
    }
}