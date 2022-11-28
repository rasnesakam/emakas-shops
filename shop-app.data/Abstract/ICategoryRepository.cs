using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop_app.entity;

namespace shop_app.data.Abstract
{
    public interface ICategoryRepository: IRepositoryBase<Category>
    {
        public Task<IEnumerable<Category>> GetPopularCategories();
        public Task<Category> GetCategoryByURI(string uri);

    }
	
}