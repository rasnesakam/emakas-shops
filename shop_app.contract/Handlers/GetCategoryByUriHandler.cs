using AutoMapper;
using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class GetCategoryByUriHandler: IRequestHandler<GetCategoryByURIRequest, ServiceResult<CategoryDto>>
{
    private readonly ICategoryService _service;
    private readonly IMapper _mapper;
    
    public GetCategoryByUriHandler(ICategoryService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<ServiceResult<CategoryDto>> Handle(GetCategoryByURIRequest request, CancellationToken cancellationToken)
    {
        var result = await _service.GetCagetoryByURI(request.Uri);
        switch (result.Status)
        {
            case ResultStatus.Success:
                return new SuccessStatus<CategoryDto>(_mapper.Map<CategoryDto>(result.Payload));
            case ResultStatus.NotFound:
                return new NotFoundErrorResult<CategoryDto>();
            default:
                return new InternalServerErrorResult<CategoryDto>(result.Exception);
        }
    }
}