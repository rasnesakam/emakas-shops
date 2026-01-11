using System.Diagnostics;
using System.Security.AccessControl;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using shop_app.api.ControllerExtensions;
using shop_app.contract.Requests.Commands;
using shop_app.contract.Requests.Queries;

namespace shop_app.api.Controllers
{
    public class MediaController : Controller
    {
        private readonly IMediator _mediator;
        
        public MediaController(IConfiguration config, IHttpContextAccessor accessor, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/Get/{objectKey}")]
        public async Task<ActionResult<string>> RedirectToS3GetUrl([FromRoute] string objectKey)
        {
            var s3Url = await _mediator.Send(new GetMediaUrlRequest() { ObjectKey = objectKey });
            return s3Url is { Succeed: true, Value: not null }? Redirect(s3Url.Value) : this.FromResult(s3Url);
        }

        [HttpPost]
        [Route("/Upload")]
        public async Task<ActionResult<string>> SubmitFile(IFormFile? file)
        {
            if (file == null)
            {
                return BadRequest(new {message="File field should not be null"});
            }

            await using var stream = file.OpenReadStream();
            var serviceResult = await _mediator.Send(new UploadFileRequest()
            {
                Size = file.Length,
                ContentType = file.ContentType,
                FileName = file.FileName,
                Stream = stream
            });
            return this.FromResult(serviceResult);
        }
    }
}
