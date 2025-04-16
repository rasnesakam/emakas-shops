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

        

        [HttpPost]
        [Route("Submit")]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] CategoryDto categorydto)
        {
            var response = await _mediator.Send(new SubmitCategoryRequest
            {
                Category = new Category
                {
                    Name = categorydto.Name,
                    //SellerId = categorydto.SellerId,
                    URI = categorydto.Uri
                }
            });
            return this.FromResult(response);
        }

        [HttpPut]
        [Route("Status/{uri}")]
        public async Task<ActionResult<Category>> ToggleStatus([FromRoute] string uri)
        {
            var categoryResponse = await _mediator.Send(new GetCategoryByURIRequest { Uri = uri });
            if (categoryResponse.Succeed)
            {
                var category = categoryResponse.Value!;
                category.Status = category.Status == Status.DRAFT ? Status.PUBLISHED : Status.DRAFT;
                var statusResponse = await _mediator.Send(
                    new UpdateCategoryRequest { Category = category });
                return this.FromResult(statusResponse);
            }
            return NotFound();
        }
        
        [HttpDelete]
        [Route("Delete/{uri}")]
        public async Task<ActionResult<Category>> DeleteCategory([FromRoute] string uri)
        {
            var response = await _mediator.Send(new DeleteCategoryCommand()
            {
                URI = uri
            });
            return this.FromResult(response);
        }

    }
}
