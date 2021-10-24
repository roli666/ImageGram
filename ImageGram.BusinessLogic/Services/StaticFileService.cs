using ImageGram.Core.Interfaces;
using ImageGram.Infrastructure.Entities;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ImageGram.Core.Services
{
    public class StaticFileService : IFileService
    {
        private static readonly string uploadDirectory = $"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}UploadedImages{Path.DirectorySeparatorChar}";
        public async Task CreateFile(Image image, byte[] imageBytes)
        {
            var path = $"{uploadDirectory}{image.FileName}";
            using var fileStream = new FileStream(path: path, FileMode.Create);
            await fileStream.WriteAsync(imageBytes);
            fileStream.Close();
        }

        public FileStream ServeImage(Image image)
        {
            return File.OpenRead($"{uploadDirectory}{image.FileName}");
        }
    }
}