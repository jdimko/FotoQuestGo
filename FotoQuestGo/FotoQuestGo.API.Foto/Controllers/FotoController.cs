using FotoQuestGo.API.Foto.FileStorage;
using FotoQuestGo.API.Foto.ImageResize;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FotoQuestGo.API.Foto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotoController : ControllerBase
    {
        private readonly IFotoStorage _storage;
        private readonly IImageResize _resize;

        public FotoController(IFotoStorage storage, IImageResize resize)
        {
            _storage = storage;
            _resize = resize;
        }

        [HttpPost]
        [Route("/api/[controller]/Upload")]
        public async Task<IActionResult> UploadAsync([FromForm] IFormFile foto)
        {
            var URI = await _storage.PersistAsync(foto);
            return new OkObjectResult(URI);
        }

        [HttpGet]
        [Route("/api/[controller]/Download/{URI}")]
        public IActionResult Download(string URI)
        {
            var image = _storage.Get(URI);
            return File(image, "image/jpg");
        }

        [HttpGet]
        [Route("/api/[controller]/Download/Thumbnail/{URI}")]
        public IActionResult DownloadThumbnail(string URI)
        {
            var resized = _resize.GetThumbnailImage(URI);
            var image = _storage.Get(resized);
            return File(image, "image/jpg");
        }

        [HttpGet]
        [Route("/api/[controller]/Download/Small/{URI}")]
        public IActionResult DownloadSmall(string URI)
        {
            var resized = _resize.GetSmallImage(URI);
            var image = _storage.Get(resized);
            return File(image, "image/jpg");
        }

        [HttpGet]
        [Route("/api/[controller]/Download/Large/{URI}")]
        public IActionResult DownloadLarge(string URI)
        {
            var resized = _resize.GetLargeImage(URI);
            var image = _storage.Get(resized);
            return File(image, "image/jpg");
        }

        [HttpGet]
        [Route("/api/[controller]/Download/Custom/{URI}/{size}")]
        public IActionResult DownloadCustom(string URI, int size)
        {
            var resized = _resize.GetImage(URI, size);
            var image = _storage.Get(resized);
            return File(image, "image/jpg");
        }
    }
}