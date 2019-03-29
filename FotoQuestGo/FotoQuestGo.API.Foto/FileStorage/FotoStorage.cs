using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FotoQuestGo.API.Foto.FileStorage
{
    public class FotoStorage : IFotoStorage
    {
        private readonly string RootPath;

        public FotoStorage()
        {
            RootPath = Directory.GetCurrentDirectory() + string.Format(@"\FileStorage\Uploads\");
        }

        public FileStream Get(string URI)
        {
            var image = File.OpenRead(RootPath + URI);
            return image;
        }

        public async Task<string> PersistAsync(IFormFile foto)
        {
            var URI = Guid.NewGuid().ToString();
            using (var stream = new FileStream(RootPath + URI, FileMode.Create))
            {
                await foto.CopyToAsync(stream);
                return URI;
            }
        }
    }
}