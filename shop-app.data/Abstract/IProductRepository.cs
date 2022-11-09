using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop_app.entity;

namespace shop_app.data.Abstract
{
    public interface IProductRepository
    {
        Product GetById(Guid id);

		List<Product> GetAll();

		void Create(Product entity);

		void Update(Product entity);

		void Delete(Guid id);
    }
}