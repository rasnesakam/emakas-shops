using MediatR;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class GQueryHandler<TEntity>: IRequestHandler<GQueryRequest<TEntity>,ServiceResult<IEnumerable<TEntity>>>
    where TEntity: class, new()
{
    private readonly IServiceBase<TEntity> _service;

    public GQueryHandler(IServiceBase<TEntity> service)
    {
        _service = service;
    }

    public async Task<ServiceResult<IEnumerable<TEntity>>> Handle(GQueryRequest<TEntity> request, CancellationToken cancellationToken)
    {
        var result = await _service.GetAllBy(request.Predicate ?? (entity => true) , request.Included! );
        return result.Status switch
        {
            ResultStatus.Success => new SuccessStatus<IEnumerable<TEntity>>(result.Payload),
            ResultStatus.NotFound => new NotFoundErrorResult<IEnumerable<TEntity>>("Item Not Found"),
            _ => new InternalServerErrorResult<IEnumerable<TEntity>>(result.Message, result.Exception)
        };
    }
}