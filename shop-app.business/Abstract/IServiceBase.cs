using shop_app.shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.service.Abstract
{
    public interface IServiceBase<TEntity>
        where TEntity : class
    {
        Task<IDataResult<TEntity>> GetOne(Guid id);

        Task<IDataResult<IEnumerable<TEntity>>> GetAll();

        Task<IResult> Create(TEntity entity);

        Task<IResult> Update(TEntity entity);

        Task<IResult> Delete(TEntity entity);
    }
}
