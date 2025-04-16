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
        /// <summary>
        /// Get Orders for seller
        /// </summary>
        /// <param name="guid">
        /// id of the seller
        /// </param>
        /// <returns>
        /// Enumerable list of <see cref="shop_app.entity.Order"/>
        /// </returns>
        /// <exception cref="shop_app.data.Exceptions.NoElementFoundException">
        /// in case of no data founded
        /// </exception>
        Task<IEnumerable<Order>> GetOrdersBySellerId(Guid guid);
        
        /// <summary>
        /// Get orders for customer
        /// </summary>
        /// <param name="guid">
        /// id of the customer
        /// </param>
        /// <returns>
        /// Enumerable list of <see cref="shop_app.entity.Order"/>
        /// </returns>
        Task<IEnumerable<Order>> GetOrdersByCustomerId(Guid guid);
    }
}
