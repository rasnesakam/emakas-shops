using System.Collections;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.data.Abstract;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using shop_app.contract.DTO;

namespace shop_app.contract.Handlers;

public class SearchProductByNameHandler: IRequestHandler<SearchProductsByName,ServiceResult<IEnumerable<ProductDto>>>
{
    private readonly IProductService _service;
    private readonly IMapper _mapper;
    
    public SearchProductByNameHandler(IProductService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }


    public async Task<ServiceResult<IEnumerable<ProductDto>>> Handle(SearchProductsByName request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAllBy(p => EF.Functions.ILike(p.Name,$"%{request.Name}%"));
        switch (response.Status)
        {
            case ResultStatus.Success:
                return new SuccessStatus<IEnumerable<ProductDto>>(response.Payload.Select(p => _mapper.Map<ProductDto>(p)));
            case ResultStatus.NotFound:
                return new NotFoundErrorResult<IEnumerable<ProductDto>>();
            default:
                return new InternalServerErrorResult<IEnumerable<ProductDto>>();
        }
    }
}
