using System.Linq.Expressions;
using MediatR;
using shop_app.contract.ServiceResults;

namespace shop_app.contract.Requests.Queries;

public class GQueryRequest<TEntity>: IRequest<ServiceResult<IEnumerable<TEntity>>>
    where TEntity: class, new()
{
    public Expression<Func<TEntity, bool>>? Predicate { get; }
    public Expression<Func<TEntity, object>>[]? Included { get; }

    public GQueryRequest(Expression<Func<TEntity, bool>>? predicate, params Expression<Func<TEntity, object>>[]? included)
    {
        Predicate = predicate;
        Included = included;
    }
}