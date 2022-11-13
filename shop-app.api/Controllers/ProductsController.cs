using Microsoft.AspNetCore.Mvc;

namespace shop_app.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet(Name = "GetAll")]
        public string GetProducts()
        {
            return "SEA";
        }
    }
}
