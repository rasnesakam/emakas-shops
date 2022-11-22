using Microsoft.EntityFrameworkCore;
using shop_app.data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace shop_app.data.Concrete.EfCore
{
    public class EfCoreRepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {

        protected readonly DbContext dbContext;

        public EfCoreRepositoryBase(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(TEntity entity)
        {
            dbContext.Set<TEntity>().AddAsync(entity);
            dbContext.SaveChanges();
            
        }

        public void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            dbContext.SaveChanges();
        }

        public Task<List<TEntity>> GetAll()
        {
            return dbContext.Set<TEntity>().ToListAsync();
        }

        public Task<TEntity> GetById(Guid id)
        {
            return dbContext.Set<TEntity>().FindAsync(id).AsTask();
        }

        public void Update(TEntity entity)
        {
            ThreadPool.;
        }
    }
}
