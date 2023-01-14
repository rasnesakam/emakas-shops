using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop_app.entity;

namespace shop_app.data.Abstract
{
    public interface IProductRepository: IRepositoryBase<Product>
    {
        /// <summary>
        /// Get All products according to their category
        /// </summary>
        /// <param name="category">
        /// Category of the products that requested
        /// </param>
        /// <returns>
        /// Enumerable list of <see cref="shop_app.entity.Product"/>
        /// </returns>
        /// <exception cref="shop_app.data.Exceptions.NoElementFoundException">
        /// in case of no data found
        /// </exception>
        public Task<IEnumerable<Product>> GetAllByCategory(Category category);
        
        /// <summary>
        /// Get one product by it's uri
        /// </summary>
        /// <param name="uri">
        /// uri of the product.
        /// <para>
        /// Uri of the product is generally like:
        /// </para>
        /// <code>
        /// lover-cased-and-dashed-name-[LAST_PART_OF_URI]
        /// </code>
        /// </param>
        /// <returns></returns>
        public Task<Product> GetByUri(string uri);
    }
}