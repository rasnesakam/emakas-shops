using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace shop_app.data.Abstract
{
    public interface IRepositoryBase<E>
    {
        Task<E> GetById(Guid id);

		Task<IEnumerable<E>> GetAll();

        Task<IEnumerable<E>> GetPart(int start, int size);

        Task<IEnumerable<E>> GetAllBy(Expression<Func<E,bool>> predicate, params Expression<Func<E, object>>[] included);

		Task Create(E entity);

		Task Update(E entity);

        Task Delete(E entity);

        Task<int> SaveChanges();
    }
}