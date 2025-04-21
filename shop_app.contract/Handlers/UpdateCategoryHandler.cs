using AutoMapper;
using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.Requests.Commands;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;
using shop_app.shared.Utilities.Results.Concrete;

namespace shop_app.contract.Handlers;

public class UpdateCategoryHandler: IRequestHandler<UpdateCategoryRequest, ServiceResult<CategoryDto>>
{
    private readonly ICategoryService _service;
    private readonly IMapper _mapper;

    public UpdateCategoryHandler(ICategoryService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    public async Task<ServiceResult<CategoryDto>> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        IDataResult<Category> oldCategoryResult = new DataResult<Category>(ResultStatus.NotFound);
        if (request.CategoryId.HasValue)
            oldCategoryResult = await _service.GetOne(request.CategoryId.Value);
        else if (!string.IsNullOrEmpty(request.CategoryUri))
            oldCategoryResult = await _service.GetCagetoryByURI(request.CategoryUri);
        if (oldCategoryResult.Status != ResultStatus.Success)
            return new NotFoundErrorResult<CategoryDto>();
        var newCategory = _mapper.Map<Category>(request.Category);
        newCategory.Id = oldCategoryResult.Payload.Id;
        var response = await _service.Update(newCategory);
        return response.Status switch
        {
            ResultStatus.Success => new SuccessStatus<CategoryDto>(request.Category),
            _=> new InternalServerErrorResult<CategoryDto>(response.Message, response.Exception)
        };
    }
}