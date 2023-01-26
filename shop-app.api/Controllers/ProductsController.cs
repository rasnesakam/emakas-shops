using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using shop_app.api.ControllerExtensions;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.contract.DTO;
using shop_app.contract.Requests.Commands;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace shop_app.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        [Route("Page")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery]int page, [FromQuery]int size) // Query
        {
            var response = await _mediator.Send(new GetAllProductsRequest {Page=page, Size=size});
            return this.FromResult(response);
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() // Query
        {
            return await GetProducts(0,0);
        }

        [HttpGet]
        [Route("Name/{productName}")]
        public async Task<ActionResult<Product>> GetProductByNameAsync(string name)
        {
            var response = await _mediator.Send(new GetProductByNameRequest { Name = name});
            return this.FromResult(response);
        }
        
        
        [HttpGet]
        [Route("Search/{productName}")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProductByNameAsync([FromRoute] string productName)
        {
            var response = await _mediator.Send(new SearchProductsByName() { Name = productName});
            return this.FromResult(response);
        }

        [HttpGet]
        [Route("Category/{categoryUri}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory([FromRoute]string categoryUri) // Error result, SuccessResult falan filan
        {
            var categoryResult = await _mediator.Send(new GetCategoryByURIRequest {Uri = categoryUri});
            if (categoryResult.Succeed)
            {
                var productResult = await _mediator.Send(new GetProductsByCategoryRequest(categoryResult.Value));
                return this.FromResult(productResult);
            }
            return BadRequest(new NotFoundErrorResult<IEnumerable<Product>>("There is no such category"));
        }
    }
}
