using Microsoft.AspNetCore.Mvc;
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

        [HttpGet(Name = "GetAll")]
        public string GetProducts()
        {
            return "SEA";
        }

    }
}
