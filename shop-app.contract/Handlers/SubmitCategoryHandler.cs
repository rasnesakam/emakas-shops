using MediatR;
using shop_app.contract.Requests.Commands;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class SubmitCategoryHandler: IRequestHandler<SubmitCategoryRequest,ServiceResult<Category>>
{
    private ICategoryService _service;

    public SubmitCategoryHandler(ICategoryService service)
    {
        _service = service;
    }

    public async Task<ServiceResult<Category>> Handle(SubmitCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = await _service.Create(request.Category);
        return response.Status switch
        {
            ResultStatus.Success => new SuccessStatus<Category>(request.Category),
            _=> new InternalServerErrorResult<Category>(response.Message, response.Exception)
        };
    }
}