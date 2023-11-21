using System.Linq.Expressions;
using MediatR;
using shop_app.contract.ServiceResults;
using shop_app.service.Abstract;

namespace shop_app.contract.Requests.Commands;

public class GCommandRequest<TEntity>: IRequest<ServiceResult<TEntity>>
    where TEntity: class, new()
{
    public Func<IServiceBase<TEntity>,Task<ServiceResult<TEntity>>> Command { get; set; }

}