using Microsoft.AspNetCore.Mvc;
using shop_app.entity;
using shop_app.service.Abstract;

namespace shop_app.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("submit")]
        public void SubmitOrder([FromBody] Order order) //TODO: Result yapısı
        {

        }
    }
}
