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
        TEntity GetEntity(Guid id);

        List<TEntity> GetEntities();

        void CreateEntity(TEntity entity);

        void UpdateEntity(TEntity entity);

        void DeleteEntity(TEntity entity);
    }
}
