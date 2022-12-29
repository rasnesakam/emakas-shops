using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop_app.entity;

namespace shop_app.data.Abstract
{
    public interface IProductRepository: IRepositoryBase<Product>
    {
        public Task<IEnumerable<Product>> GetAllByCategory(Category category);
        public Task<Product> GetByUri(string uri);
    }
}