using System.Diagnostics;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;

namespace shop_app.api.Controllers
{
    public class MediaController : Controller
    {
        private static readonly long MaxImageSize = 1000000;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _accessor;
        private readonly string allowedMimeTypes = "image/jpg, image/jpeg, image/png";
        
        public MediaController(IConfiguration config, IHttpContextAccessor accessor)
        {
            _config = config;
            _accessor = accessor;
        }

        [HttpPost]
        [Route("/Image")]
        public async Task<IActionResult> SubmitFile([FromForm(Name = "file")]IFormFile? file)
        {
            if (file == null)
            {
                return BadRequest(new {message="File field should not be null"});
            }
            if (!allowedMimeTypes.Split(", ").Any(mime => mime.Equals(file.ContentType)))
                return BadRequest(new { message = "Invalid File Type. Please upload jpeg, jpg or png" });
            if (file.Length < MaxImageSize)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var wwwroot = _config["StoredFilesPath"];
                var mediaDir = "media";
                Directory.CreateDirectory(Path.Combine(wwwroot, mediaDir));
                var mediaUriString = Path.Combine(mediaDir, fileName);
                var filePath = Path.Combine(wwwroot,mediaUriString);
                await using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                var request = _accessor.HttpContext!.Request;
                var contentUri = new UriBuilder($"{request.Scheme}://{request.Host.ToString()}/{mediaUriString}").Uri;
                return Created(contentUri, new {file=contentUri.ToString()});
            }
            return BadRequest(new {message=$"File must be smaller than {MaxImageSize} bytes"});
        }
    }
}
