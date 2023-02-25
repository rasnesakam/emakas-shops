using Microsoft.AspNetCore.Mvc;

namespace shop_app.api.Controllers
{
    public class MediaController : Controller
    {
        private static readonly long MAX_IMAGE_SIZE = 1000000;
        private readonly IConfiguration _config;

        public MediaController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("/Image")]
        public async Task<IActionResult> SubmitFile(IFormFile file)
        {
            if (file.Length < MAX_IMAGE_SIZE)
            {
                var fileName = $"{Guid.NewGuid()}_{file.FileName}";
                var filePath = Path.Combine(_config["StoredFilesPath"],"images",fileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                return Ok(new {file=filePath});
            }
            return BadRequest(new {message=$"File must be smaller than {MAX_IMAGE_SIZE} bytes"});
        }
    }
}
