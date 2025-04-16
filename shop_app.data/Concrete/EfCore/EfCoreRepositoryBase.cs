using Microsoft.EntityFrameworkCore;
using shop_app.data.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using shop_app.data.Exceptions;
using System.Linq.Expressions;

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
            var result = await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task CreateBatch(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities,cancellationToken);
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
            else throw new NoElementFoundException();
        }

        public async Task<IEnumerable<TEntity>> GetAllBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] included)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            query = query.Where(predicate);
            if (included.Any())
            {
                foreach (var includedItem in included)
                {
                    query = query.Include(includedItem);
                }
            }
            var list = await query.ToListAsync();
            return list.Any() ? list : throw new NoElementFoundException();
        }

        public async Task<IEnumerable<TEntity>> GetPart(int start, int size)
        {
            if (start >= 0 && size >= 0)
            {
                var list = await _dbContext.Set<TEntity>().Skip(start).Take(size).ToListAsync();
                if (list.Any())
                    return list;
                throw new NoElementFoundException();
            }
            throw new ArgumentException();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            TEntity? entity = await _dbContext.Set<TEntity>().FindAsync(id).AsTask();
            if (entity == null)
                throw new NoElementFoundException();
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
                throw new DbSavingException(exception.Message, exception);
            }
            catch (OperationCanceledException exception)
            {
                throw new DbSavingException(exception.Message, exception);
            }
        }

        public async Task Update(TEntity entity)
        {
            await Task.Run( () => _dbContext.Entry(entity).State = EntityState.Modified);
        }
    }
}
