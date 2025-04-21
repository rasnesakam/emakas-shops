using AutoMapper;
using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class GetAllCategoriesHandler: IRequestHandler<GetAllCategoriesRequest,ServiceResult<IEnumerable<CategoryDto>>>
{
    private readonly ICategoryService _service;
    private readonly IMapper _mapper;

    public GetAllCategoriesHandler(ICategoryService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<ServiceResult<IEnumerable<CategoryDto>>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        var result = await _service.GetAll();
        switch (result.Status)
        {
            case ResultStatus.Success:
                return new SuccessStatus<IEnumerable<CategoryDto>>(result.Payload.Select(c => _mapper.Map<CategoryDto>(c)));
            case ResultStatus.NotFound:
                return new NotFoundErrorResult<IEnumerable<CategoryDto>>(result.Message);
            default:
                return new InternalServerErrorResult<IEnumerable<CategoryDto>>(result.Message, result.Exception);
        }
    }
}