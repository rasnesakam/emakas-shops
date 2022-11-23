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
        Task<IDataResult<TEntity>> GetEntity(Guid id);

        Task<IDataResult<List<TEntity>>> GetEntities();

        Task<IResult> CreateEntity(TEntity entity);

        Task<IResult> UpdateEntity(TEntity entity);

        Task<IResult> DeleteEntity(TEntity entity);
    }
}
