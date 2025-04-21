using AutoMapper;
using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.Requests.Commands;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class SubmitCategoryHandler: IRequestHandler<SubmitCategoryRequest,ServiceResult<CategoryDto>>
{
    private readonly ICategoryService _service;
    private readonly IMapper _mapper;

    public SubmitCategoryHandler(ICategoryService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<ServiceResult<CategoryDto>> Handle(SubmitCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = await _service.Create(_mapper.Map<Category>(request.Category));
        return response.Status switch
        {
            ResultStatus.Success => new SuccessStatus<CategoryDto>(request.Category),
            _=> new InternalServerErrorResult<CategoryDto>(response.Message, response.Exception)
        };
    }
}