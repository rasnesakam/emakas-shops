using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using shop_app.api.ControllerExtensions;
using shop_app.contract.DTO;
using shop_app.contract.Requests.Commands;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace shop_app.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        [Route("Page")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories([FromQuery]int page, [FromQuery]int size) // Query
        {
            var response = await _mediator.Send(new GetAllCategoriesRequest {Page=page, Size=size});
            return this.FromResult(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories() // Query
        {
            return await GetCategories(0,0);
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
        public async Task<ActionResult<IEnumerable<Product>>> SearchProductByNameAsync(string name)
        {
            var response = await _mediator.Send(new SearchProductsByName() { Name = name});
            return this.FromResult(response);
        }

        [HttpPost]
        [Route("Submit")]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] CategoryDto categorydto)
        {
            var response = await _mediator.Send(new SubmitCategoryRequest
            {
                Category = new Category
                {
                    Name = categorydto.Name,
                    SellerId = categorydto.SellerId,
                    URI = categorydto.Uri
                }
            });
            return this.FromResult(response);
        }

        // [HttpGet]
        // [Route("Category/{categoryURI}")]
        // public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory([FromRoute]string categoryURI) // Error result, SuccessResult falan filan
        // {
        //     var categoryResult = await _mediator.Send(new GetCategoryByURIRequest(categoryURI));
        //     if (categoryResult.Succeed)
        //     {
        //         var productResult = await _mediator.Send(new GetProductsByCategoryRequest(categoryResult.Value));
        //         return this.FromResult(productResult);
        //     }
        //     return BadRequest("There is no such category");
        // }
    }
}
