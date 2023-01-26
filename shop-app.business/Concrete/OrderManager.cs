using shop_app.data.Abstract;
using shop_app.data.Exceptions;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;
using shop_app.shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.service.Concrete
{
    public class OrderManager : ServiceBase<Order>, IOrderService
    {
        public OrderManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IDataResult<IEnumerable<Order>>> GetAllByCustomerId(Guid userId)
        {
            try
            {
                var orders = await _unitOfWork.OrdersRepository.GetOrdersByCustomerId(userId);
                return new DataResult<IEnumerable<Order>>(orders);
            }
            catch (NoElementFoundException exception)
            {
                return new DataResult<IEnumerable<Order>>(exception);
            }
        }

        public async Task<IDataResult<IEnumerable<Order>>> GetAllBySellerId(Guid userId)
        {
            try
            {
                var orders = await _unitOfWork.OrdersRepository.GetOrdersBySellerId(userId);
                return new DataResult<IEnumerable<Order>>(orders);
            }
            catch (NoElementFoundException exception)
            {
                return new DataResult<IEnumerable<Order>>(exception);
            }
        }

    }
}
