using ImageGram.Core.ApiModels;
using ImageGram.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageGram.Core.Interfaces
{
    public interface IPostService
    {
        Task<Post> CreatePost(CreatePostDTO post);
        Task<Post> UpdatePost(int postId, CreatePostDTO updatedPost);
        Task<Post> DeletePost(int postId);
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPost(int postId);
    }
}