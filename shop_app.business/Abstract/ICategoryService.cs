using shop_app.entity;
using shop_app.shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.service.Abstract
{
    public interface ICategoryService: IServiceBase<Category>
    {
        Task<IDataResult<Category>> GetCagetoryByURI(string uri);
        Task<IDataResult<IEnumerable<Category>>> GetPopularCategories();
    }
}
