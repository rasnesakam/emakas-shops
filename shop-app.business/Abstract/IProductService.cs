using shop_app.entity;
using shop_app.shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.service.Abstract
{
    public interface IProductService: IServiceBase<Product>
    {
        Task<IDataResult<IEnumerable<Product>>> GetAllByCategory(Category category);
    }
}
