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
    public class EfCoreReviewRepository : EfCoreRepositoryBase<Review>, IReviewRepository
    {
        public EfCoreReviewRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Review>> GetReviewsByProduct(Product product)
        {
            return await _dbContext.Set<Review>().Where(r => r.ProductId == product.Id).ToListAsync();
        }
    }
}
