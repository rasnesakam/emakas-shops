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
    public class EfCoreOrderRepository : EfCoreRepositoryBase<Order>, IOrderRepository
    {
        public EfCoreOrderRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public List<Order> GetOrdersByUserId(Guid guid)
        {
            return _dbContext.Set<Order>().Where(o => o.UserId == guid).ToList();
        }
    }
}
