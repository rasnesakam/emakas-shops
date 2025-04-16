using Microsoft.EntityFrameworkCore;
using shop_app.data.Abstract;
using shop_app.data.Exceptions;
using shop_app.entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreRepositoryBase<Product>, IProductRepository
    {
        public EfCoreProductRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Product> GetByUri(string uri)
        {
            Product? product = await _dbContext.Set<Product>().Where(p => p.Uri == uri)
                .Include(p => p.ProductImages).FirstOrDefaultAsync();
            if (product == null)
                throw new NoElementFoundException($"Element couldn't found with uri: '{uri}'");
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllByCategory(Category category)
        {
            IEnumerable<Product> products = await _dbContext.Set<Product>()
                .Where(p => p.Categories.Any(c => c.URI == category.URI))
                .Include(p => p.ProductImages ).ToListAsync();
            if (products.Any())
                return products;
            throw new NoElementFoundException($"Element couldn't found with category {category.Name ?? category.URI}");
        }

        public async Task<IEnumerable<Product>> Search(string search)
        {
            IEnumerable<Product> products = await _dbContext.Set<Product>()
                .Where(p => EF.Functions.Like(p.Name,$"%{search}%")).ToListAsync();
            if (products.Any())
                return products;
            throw new NoElementFoundException();
        }
        
    }
}
