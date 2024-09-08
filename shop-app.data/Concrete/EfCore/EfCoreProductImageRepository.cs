using Microsoft.EntityFrameworkCore;
using shop_app.data.Abstract;
using shop_app.entity;

namespace shop_app.data.Concrete.EfCore;

public class EfCoreProductImageRepository: EfCoreRepositoryBase<ProductImage>, IProductImageRepository
{
    public EfCoreProductImageRepository(DbContext dbContext) : base(dbContext)
    {
    }
}