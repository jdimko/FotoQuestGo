using FotoQuestGo.API.Foto.FileStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FotoQuestGo.API.Foto.ImageResize
{
    public class ImageResize : IImageResize
    {
        //thumbnail -> 128px, /small -> 512px, /large -> 2048px

        private string MakeResizedImage(string fromFile, int maxWidth, int maxHeight)
        {
            //TODO Implement resize logic and retrun new file
            //actually returns same file for test to pass through
            //return fromFile + "_" + maxWidth + "_" + maxHeight;

            return fromFile;
        }

        public string GetImage(string filename, int size)
        {
            var resizedImaged = MakeResizedImage(filename, size, size);
            return resizedImaged;
        }

        public string GetLargeImage(string filename)
        {
            return GetImage(filename, 2048);
        }

        public string GetSmallImage(string filename)
        {
            return GetImage(filename, 512);
        }

        public string GetThumbnailImage(string filename)
        {
            return GetImage(filename, 128);
        }
    }
}