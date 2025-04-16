using shop_app.shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.service.Abstract
{
    public interface IServiceBase<TEntity>
        where TEntity : class
    {
        Task<IDataResult<TEntity>> GetOne(Guid id);

        Task<IDataResult<IEnumerable<TEntity>>> GetAll();
        
        Task<IDataResult<IEnumerable<TEntity>>> 
            GetAllBy(Expression<Func<TEntity,bool>> predicate, params Expression<Func<TEntity, object>>[] included);

        Task<IDataResult<IEnumerable<TEntity>>> GetPart(int start, int size);

        Task<IResult> Create(TEntity entity);

        Task<IResult> CreateBatch(IEnumerable<TEntity> entities, CancellationToken token);

        Task<IResult> Update(TEntity entity);

        Task<IResult> Delete(TEntity entity);
    }
}
