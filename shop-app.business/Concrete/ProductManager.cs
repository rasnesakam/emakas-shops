using shop_app.data.Abstract;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;
using shop_app.shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.service.Concrete
{
    public class ProductManager : ServiceBase<Product>, IProductService
    {
        public ProductManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IDataResult<IEnumerable<Product>>> GetAllByCategory(Category category)
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.GetProductsByCategory(category);
                return new DataResult<IEnumerable<Product>>(products);
            }
            catch (Exception e)
            {
                return new DataResult<IEnumerable<Product>>(e);
            }
        }
    }
}
