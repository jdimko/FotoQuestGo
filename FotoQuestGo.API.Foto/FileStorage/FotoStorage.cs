using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FotoQuestGo.API.Foto.FileStorage
{
    public class FotoStorage : IFotoStorage
    {
        private readonly string RootPath;

        public FotoStorage()
        {
            RootPath = Directory.GetCurrentDirectory() + string.Format(@"\FileStorage\Uploads\");
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