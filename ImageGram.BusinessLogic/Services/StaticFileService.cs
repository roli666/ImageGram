using ImageGram.Core.Interfaces;
using ImageGram.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGram.Core.Services
{
    public class StaticFileService : IFileService
    {
        private static readonly string uploadDirectory = $"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}UploadedImages{Path.DirectorySeparatorChar}";

        private static readonly Dictionary<byte[], string> FileSignaturesToExtensions = new()
        {
            { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, "png" },
            { new byte[] { 0xFF, 0xD8, 0xFF, 0xE0, 0x00, 0x10, 0x4A, 0x46, 0x49, 0x46, 0x00, 0x01 }, "jpg" },
            { new byte[] { 0x42, 0x4D }, "bmp" },
        };

        public async Task CreateFile(Image image, byte[] imageBytes)
        {
            var path = $"{uploadDirectory}{image.FileName}";
            using var fileStream = new FileStream(path: path, FileMode.Create);
            await fileStream.WriteAsync(imageBytes);
            fileStream.Close();
        }

        public Stream ServeImage(Image image)
        {
            var img = System.Drawing.Image.FromFile($"{uploadDirectory}{image.FileName}");
            var stream = new MemoryStream();
            img.Save(stream, ImageFormat.Jpeg);
            return stream;
        }

        public string GuessFileExtension(byte[] fileBytes)
        {
            foreach (var signature in FileSignaturesToExtensions)
            {
                if (fileBytes.Take(signature.Key.Length).SequenceEqual(signature.Key))
                {
                    return signature.Value;
                }
            }
            return "jpg";
        }
    }
}