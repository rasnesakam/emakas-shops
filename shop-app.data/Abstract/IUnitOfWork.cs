using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.data.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IOrderRepository OrdersRepository { get; }
        IAddressRepository AddressRepository { get; }
        IRepositoryBase<T> GetRepository<T>() where T: class;
        

    }
}
