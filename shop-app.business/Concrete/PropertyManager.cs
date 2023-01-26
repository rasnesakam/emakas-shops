using shop_app.data.Abstract;
using shop_app.entity;
using shop_app.service.Abstract;

namespace shop_app.service.Concrete;

public class PropertyManager: ServiceBase<Property>, IPropertyService
{
    public PropertyManager(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}