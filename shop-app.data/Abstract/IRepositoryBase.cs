using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_app.data.Abstract
{
    public interface IRepositoryBase<E>
    {
        Task<E> GetById(Guid id);

		Task<IEnumerable<E>> GetAll();

		Task Create(E entity);

		Task Update(E entity);

        Task Delete(E entity);

        Task<int> SaveChanges();
    }
}