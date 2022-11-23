using Microsoft.AspNetCore.Mvc;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;
using System.Collections;

namespace shop_app.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("All")]
        public async Task<IEnumerable<Product>> GetProducts() // Query
        {
            IDataResult<List<Product>> response =  await _productService.GetEntities();
            if (response.Status == ResultStatus.Success)
            {
                return response.Payload;
            }
            else return new List<Product>();
        }

        [HttpGet("{category}")] // Query
        public IEnumerable<Product> GetProductsByCategory(string category) // Error result, SuccessResult falan filan
        {
            Category searchCategory = new Category() { URL = category };
            return _productService.GetAllByCategory(searchCategory);
        }
    }
}
