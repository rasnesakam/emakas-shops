using System.Linq.Expressions;
using MediatR;
using shop_app.contract.ServiceResults;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;

namespace shop_app.contract.Requests.Commands;

public class GCommandRequest<TEntity>: IRequest<ServiceResult<TEntity>>
    where TEntity: class, new()
{
    public GCommandRequest(Func<IServiceBase<TEntity>, Task<IResult>> command)
    {
        Command = command;
    }

    public Func<IServiceBase<TEntity>,Task<IResult>> Command { get; }

}