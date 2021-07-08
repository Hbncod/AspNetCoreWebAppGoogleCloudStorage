using AspNetCoreWebApp.CloudStorage;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading.Tasks;

namespace AspNetCoreWebApp.Controllers
{
    [Route("storage")]
    public class StorageController : Controller
    {
        private readonly ICloudStorage _storage;
        public StorageController(ICloudStorage storage)
        {
            _storage = storage;
        }

        [Route("{fileName}")]
        public async Task<IActionResult> Get(string fileName)
        {
            var contentType = MimeTypes.GetMimeType(fileName);
            var response = await _storage.DownloadFile(fileName);

            if (response.IsSuccessStatusCode)
                return File(response.Bytes, contentType);

            return StatusCode((int)response.StatusCode);
        }
    }
}
