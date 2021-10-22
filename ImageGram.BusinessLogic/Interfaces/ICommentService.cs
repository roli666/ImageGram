using ImageGram.Core.ApiModels;
using ImageGram.Infrastructure.Entities;
using System.Threading.Tasks;

namespace ImageGram.Core.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> AddComment(CreateCommentDTO comment);
        Task<Comment> UpdateComment(CommentDTO commentDto);
        Task<Comment> RemoveComment(int commentId);
    }
}