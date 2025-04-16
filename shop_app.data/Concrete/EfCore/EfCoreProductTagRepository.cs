using Microsoft.EntityFrameworkCore;
using shop_app.data.Abstract;
using shop_app.entity;

namespace shop_app.data.Concrete.EfCore;

public class EfCoreProductTagRepository: EfCoreRepositoryBase<ProductTag>, IProductTagRepository
{
    public EfCoreProductTagRepository(DbContext dbContext) : base(dbContext)
    {
    }
}