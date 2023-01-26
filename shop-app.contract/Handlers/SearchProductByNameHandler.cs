using System.Collections;
using MediatR;
using Microsoft.EntityFrameworkCore;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.data.Abstract;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace shop_app.contract.Handlers;

public class SearchProductByNameHandler: IRequestHandler<SearchProductsByName,ServiceResult<IEnumerable<Product>>>
{
    private IProductService _service;
    
    public SearchProductByNameHandler(IProductService service)
    {
        _service = service;
    }


    public async Task<ServiceResult<IEnumerable<Product>>> Handle(SearchProductsByName request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAllBy(p => EF.Functions.ILike(p.Name,$"%{request.Name}%"));
        switch (response.Status)
        {
            case ResultStatus.Success:
                return new SuccessStatus<IEnumerable<Product>>(response.Payload);
            case ResultStatus.NotFound:
                return new NotFoundErrorResult<IEnumerable<Product>>();
            default:
                return new InternalServerErrorResult<IEnumerable<Product>>();
        }
    }
}
