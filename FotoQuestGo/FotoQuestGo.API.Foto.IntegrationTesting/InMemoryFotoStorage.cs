using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

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