using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FotoQuestGo.API.Foto.FileStorage
{
    public class InMemoryFotoStorage : IFotoStorage
    {
        public async Task<string> PersistAsync(IFormFile foto)
        {
            var URI = Guid.NewGuid().ToString();
            return URI;
        }
    }
}