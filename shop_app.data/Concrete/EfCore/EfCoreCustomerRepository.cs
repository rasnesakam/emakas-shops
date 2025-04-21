using Microsoft.EntityFrameworkCore;
using shop_app.data.Abstract;
using shop_app.entity;

namespace shop_app.data.Concrete.EfCore;

public class EfCoreCustomerRepository: EfCoreRepositoryBase<Customer>, ICustomerRepository
{
    public EfCoreCustomerRepository(DbContext dbContext) : base(dbContext)
    {
    }
}