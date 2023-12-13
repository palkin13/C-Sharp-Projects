using FileProcessingAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileProcessingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagerController : ControllerBase
    {
        // DEPENDENCY INJECTION

        public readonly IManageImage _IManageImage;
        public FileManagerController(IManageImage IManageImage)
        {
           _IManageImage = IManageImage;
        }

        [HttpPost]
        [Route("UploadFile")]

        public async Task<IActionResult> UploadFile(IFormFile _IFormFile)
        {
            var result = await _IManageImage.UploadFile(_IFormFile);
            return Ok(result);
        }

        [HttpGet]
        [Route("DownloadFile")]

        public async Task<IActionResult> DownloadFile(string FileName)
        {
            var result = await _IManageImage.DownloadFile(FileName);
            return File(result.Item1, result.Item2, result.Item3);
        }
        


    }
}
