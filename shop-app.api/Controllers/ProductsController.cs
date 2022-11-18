using Microsoft.AspNetCore.Mvc;
using shop_app.entity;
using shop_app.service.Abstract;

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
        public IEnumerable<Product> GetProducts()
        {
            return _productService.GetEntities();
        }

        [HttpGet("{category}")]
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            Category searchCategory = new Category() { URL = category };
            return _productService.GetAllByCategory(searchCategory);
        }
    }
}
