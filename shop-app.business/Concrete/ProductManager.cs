using shop_app.data.Abstract;
using shop_app.entity;
using shop_app.service.Abstract;
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

        public List<Product> GetAllByCategory(Category category)
        {
            // Burada try catch yapabilirsin (Bağlantı, request kotrolü)
            return _unitOfWork.ProductRepository.GetProductsByCategory(category);
        }
    }
}
