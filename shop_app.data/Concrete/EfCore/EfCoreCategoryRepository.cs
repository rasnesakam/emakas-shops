using Microsoft.EntityFrameworkCore;
using shop_app.data.Abstract;
using shop_app.data.Exceptions;
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


        public async Task<Category> GetCategoryByURI(string uri)
        {
            Category? category =  await _dbContext.Set<Category>().Where(c => c.URI == uri).FirstAsync();
            if (category == null)
                throw new NoElementFoundException($"Element couldn't found with uri: {uri}");
            return category;
        }

        public async Task<IEnumerable<Category>> GetPopularCategories()
        {
            return await _dbContext.Set<Category>().ToListAsync();
        }
    }
}
