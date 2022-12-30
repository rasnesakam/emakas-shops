using shop_app.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace shop_app.data.Abstract
{
    public interface IOrderRepository: IRepositoryBase<Order>
    {
        Task<IEnumerable<Order>> GetOrdersBySellerId(Guid guid);
        Task<IEnumerable<Order>> GetOrdersByCustomerId(Guid guid);
    }
}
