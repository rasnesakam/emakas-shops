using shop_app.data.Abstract;
using shop_app.entity;
using shop_app.service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.service.Concrete
{
    public class AddressManager : ServiceBase<Address>, IAddressService
    {
        public AddressManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
