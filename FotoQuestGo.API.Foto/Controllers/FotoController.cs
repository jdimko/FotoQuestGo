using FotoQuestGo.API.Foto.FileStorage;
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

        public FotoController(IFotoStorage storage)
        {
            _storage = storage;
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
        public async Task<IActionResult> DownloadAsync(string URI)
        {
            //TODO get file and return it

            return Ok();
        }
    }
}