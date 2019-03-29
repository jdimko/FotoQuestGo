using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FotoQuestGo.API.Foto.ImageResize
{
    public interface IImageResize
    {
        //thumbnail -> 128px, /small -> 512px, /large -> 2048px

        string GetImage(string filename, int size);

        string GetThumbnailImage(string filename);

        string GetSmallImage(string filename);

        string GetLargeImage(string filename);
    }
}