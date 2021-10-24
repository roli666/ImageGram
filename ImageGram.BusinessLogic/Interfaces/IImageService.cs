using ImageGram.Core.ApiModels;
using ImageGram.Infrastructure.Entities;
using System.Threading.Tasks;

namespace ImageGram.Core.Interfaces
{
    public interface IImageService
    {
        Task<Image> CreateImage(CreateImageDTO createImageDTO);
        bool ValidateImage(byte[] imageBytes);
    }
}
