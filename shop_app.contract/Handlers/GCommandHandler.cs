using MediatR;
using shop_app.contract.Requests.Commands;
using shop_app.contract.ServiceResults;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class GCommandHandler<TEntity>: IRequestHandler<GCommandRequest<TEntity>, ServiceResult<TEntity>>
    where TEntity: class, new()
{
    private IServiceBase<TEntity> _service;

    public GCommandHandler(IServiceBase<TEntity> service)
    {
        _service = service;
    }

    public async Task<ServiceResult<TEntity>> Handle(GCommandRequest<TEntity> request, CancellationToken cancellationToken)
    {
        var result = await request.Command(_service);
        return result.Status switch
        {
            ResultStatus.Success => new SuccessStatus<TEntity>(null),
            ResultStatus.BadArgument => new BadRequestErrorResult<TEntity>(),
            ResultStatus.Error => new InternalServerErrorResult<TEntity>(result.Exception)
        };
    }
}