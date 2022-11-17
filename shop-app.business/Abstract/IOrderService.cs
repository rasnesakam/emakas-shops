using shop_app.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.service.Abstract
{
    public interface IOrderService: IServiceBase<Order>
    {
        List<Order> GetAllByUserId(Guid userId);
    }
}
