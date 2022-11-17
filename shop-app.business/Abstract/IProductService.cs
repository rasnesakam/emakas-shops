using shop_app.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.service.Abstract
{
    public interface IProductService: IServiceBase<Product>
    {
        List<Product> GetAllByCategory(Category category);
    }
}
