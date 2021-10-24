using ImageGram.Infrastructure.Entities;
using System.IO;
using System.Threading.Tasks;

namespace ImageGram.Core.Interfaces
{
    public interface IFileService
    {
        Task CreateFile(Image image, byte[] imageBytes);

        Stream ServeImage(Image image);

        string GuessFileExtension(byte[] fileBytes);
    }
}