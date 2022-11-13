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
    public class EfCoreCategoryRepository : EfCoreRepositoryBase<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(ShopContext dbContext) : base(dbContext)
        {
        }

        private ShopContext ShopContext => dbContext as ShopContext;

        public List<Category> GetPopularCategories()
        {
            return ShopContext.Set<Category>().ToList();
            
        }
    }
}
