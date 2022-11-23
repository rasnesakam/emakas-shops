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

        protected readonly DbContext _dbContext;

        public EfCoreRepositoryBase(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task Delete(TEntity entity)
        {
            await Task.Run(() => _dbContext.Set<TEntity>().Remove(entity));
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id).AsTask();
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            await Task.Run( () => _dbContext.Entry(entity).State = EntityState.Modified);
        }
    }
}
