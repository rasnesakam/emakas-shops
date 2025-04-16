using shop_app.data.Abstract;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;
using shop_app.shared.Utilities.Results.Concrete;
using shop_app.data.Exceptions;
using shop_app.shared.Utilities.Results.ComplexTypes;

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
                var products = await _unitOfWork.ProductRepository.GetAllByCategory(category);
                return new DataResult<IEnumerable<Product>>(products);
            }
            catch (NoElementFoundException e)
            {
                return new DataResult<IEnumerable<Product>>(ResultStatus.NotFound,"No element Found", e);
            }
        }

        public async Task<IDataResult<Product>> GetByUri(string uri)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByUri(uri);
                return new DataResult<Product>(product);
            }
            catch (NoElementFoundException e)
            {
                return new DataResult<Product>(ResultStatus.NotFound,"No element Found", e);
            }
        }
    }
}
