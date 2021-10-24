using ImageGram.Infrastructure.Entities;
using System.IO;
using System.Threading.Tasks;

namespace ImageGram.Core.Interfaces
{
    public interface IFileService
    {
        Task CreateFile(Image image, byte[] imageBytes);
        FileStream ServeImage(Image image);
    }
}