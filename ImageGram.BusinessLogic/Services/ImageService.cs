using ImageGram.Core.ApiModels;
using ImageGram.Core.Interfaces;
using ImageGram.Infrastructure.Data;
using ImageGram.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ImageGram.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly ImageGramDBContext dbContext;
        private readonly IFileService fileService;
        private static readonly List<byte[]> allowedImageFileSignatures = new()
        {
            { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } },
            { new byte[] { 0xFF, 0xD8, 0xFF, 0xE0, 0x00, 0x10, 0x4A, 0x46, 0x49, 0x46, 0x00, 0x01 } },
            { new byte[] { 0x42, 0x4D } },
        };


        public ImageService(ImageGramDBContext dbContext, IFileService fileService)
        {
            this.dbContext = dbContext;
            this.fileService = fileService;
        }

        public async Task<Image> CreateImage(CreateImageDTO createImageDTO)
        {
            var newImage = new Image(createImageDTO.ParentPostId);
            dbContext.Images.Add(newImage);
            await fileService.CreateFile(newImage, createImageDTO.ImageBytes);
            await dbContext.SaveChangesAsync();
            return newImage;
        }

        public bool ValidateImage(byte[] imageBytes)
        {
            foreach (var signature in allowedImageFileSignatures)
            {
                if(imageBytes.Take(signature.Length).SequenceEqual(signature))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
