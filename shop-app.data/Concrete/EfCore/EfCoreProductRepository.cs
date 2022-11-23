using Microsoft.EntityFrameworkCore;
using shop_app.data.Abstract;
using shop_app.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreRepositoryBase<Product>, IProductRepository
    {
        public EfCoreProductRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public List<Product> GetProductsByCategory(Category category)
        {
            return _dbContext.Set<Product>()
                .Where(p => p.ProductCategories.Any(pc => pc.Category.URL == category.URL)).ToList();
            
        }
    }
}
