using Microsoft.EntityFrameworkCore;
using shop_app.data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using shop_app.data.Exceptions;

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

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            IEnumerable<TEntity> entities = await _dbContext.Set<TEntity>().ToListAsync();
            if (entities.Any())
                return entities;
            else throw new NoElementFoundException("There was no element discovered.");
        }

        public async Task<TEntity> GetById(Guid id)
        {
            TEntity? entity = await _dbContext.Set<TEntity>().FindAsync(id).AsTask();
            if (entity == null)
                throw new NoElementFoundException($"Element couldn't found with id: \"{id}\"");
            return entity;
        }

        public async Task<int> SaveChanges()
        {
            try
            {
                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new DbSavingException("The database couldn't be updated.", exception);
            }
            catch (OperationCanceledException exception)
            {
                throw new DbSavingException("The database did not update due to the cancellation of the process.", exception);
            }
        }

        public async Task Update(TEntity entity)
        {
            await Task.Run( () => _dbContext.Entry(entity).State = EntityState.Modified);
        }
    }
}
