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
        
        /// <summary>
        /// Gets one category by its uri
        /// </summary>
        /// <param name="uri">
        /// uri of the category
        /// </param>
        /// <returns>Category data</returns>
        /// <exception cref="shop_app.data.Exceptions.NoElementFoundException">
        /// Throws when no element found
        /// </exception>
        public Task<Category> GetCategoryByURI(string uri);

    }
	
}