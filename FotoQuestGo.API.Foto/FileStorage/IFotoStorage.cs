using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoQuestGo.API.Foto.FileStorage
{
    public interface IFotoStorage
    {
        Task<string> PersistAsync(IFormFile foto);
    }
}