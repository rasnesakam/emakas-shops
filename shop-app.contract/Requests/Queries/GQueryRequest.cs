using System.Linq.Expressions;
using MediatR;
using shop_app.contract.ServiceResults;

namespace shop_app.contract.Requests.Queries;

public class GQueryRequest<TEntity>: IRequest<ServiceResult<IEnumerable<TEntity>>>
    where TEntity: class, new()
{
    public Expression<Func<TEntity, bool>>? Predicate;
    public Expression<Func<TEntity, object>>[]? Included;

}