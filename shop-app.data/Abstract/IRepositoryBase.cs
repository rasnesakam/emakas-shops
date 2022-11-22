using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_app.data.Abstract
{
    public interface IRepositoryBase<E>
    {
        Task<E> GetById(Guid id);

		Task<List<E>> GetAll();

		void Create(E entity);

		void Update(E entity);

        void Delete(E entity);
    }
}