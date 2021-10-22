using ImageGram.Core.ApiModels;
using ImageGram.Core.Interfaces;
using ImageGram.Infrastructure.Data;
using ImageGram.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGram.Core.Services
{
    public class PostService : IPostService
    {
        private readonly ImageGramDBContext dbContext;
        private readonly ICommentService commentService;


        public PostService(ImageGramDBContext dbContext, ICommentService commentService)
        {
            this.dbContext = dbContext;
            this.commentService = commentService;
        }

        public async Task<Post> CreatePost(CreatePostDTO post)
        {
            var newPost = dbContext.Add(new Post
            {
                AttachedImage = post.AttachedImage,
                Content = post.Content,
                Title = post.Title
            });
            await dbContext.SaveChangesAsync();
            return newPost.Entity;
        }

        public async Task<Post> DeletePost(int postId)
        {
            var post = await dbContext.Posts.FirstOrDefaultAsync(post => post.Id == postId);
            dbContext.Remove(post);
            await dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await dbContext.Posts.ToListAsync();
        }

        public async Task<Post> UpdatePost(PostDTO postDto)
        {
            var post = await dbContext.Posts.FirstOrDefaultAsync(post => post.Id == postDto.Id);
            var comments = dbContext.Comments.Where(comment => comment.ParentPostId == postDto.Id);
            dbContext.Attach(post);
            {
                post.AttachedImage = postDto.AttachedImage;
                post.Comments = comments;
                post.Content = postDto.Content;
                post.Title = postDto.Title;
            }
            await dbContext.SaveChangesAsync();
            return post;
        }
    }
}