using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_app.data.Abstract
{
    public interface IRepositoryBase<E>
    {
        E GetById(Guid id);

		List<E> GetAll();

		void Create(E entity);

		void Update(E entity);
    }
}