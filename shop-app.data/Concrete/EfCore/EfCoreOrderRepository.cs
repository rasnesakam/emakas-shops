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
    public class EfCoreOrderRepository : EfCoreRepositoryBase<Order>, IOrderRepository
    {
        public EfCoreOrderRepository(DbContext dbContext) : base(dbContext)
        {
        }

        
        public async Task<IEnumerable<Order>> GetOrdersByUserId(Guid guid)
        {
            var orders = await _dbContext.Set<Order>().Where(o => o.UserId == guid).ToListAsync();
            if (orders.Any())
                return orders;
            throw new NoElementFoundException($"No element found with user id: {guid}");
        }
    }
}
