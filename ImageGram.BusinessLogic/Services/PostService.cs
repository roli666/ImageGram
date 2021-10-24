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
            var posts = await dbContext.Posts.ToListAsync();
            foreach (var post in posts)
            {
                post.Comments = post.Comments.OrderByDescending(comment => comment.Created).Take(2);
            }
            return posts;
        }

        public async Task<Post> GetPost(int postId)
        {
            return await dbContext.Posts.FirstOrDefaultAsync(post => post.Id == postId);
        }

        public async Task<Post> UpdatePost(int postId, CreatePostDTO updatedPost)
        {
            var post = await dbContext.Posts.FirstOrDefaultAsync(post => post.Id == postId);
            var comments = dbContext.Comments.Where(comment => comment.ParentPostId == postId);
            var image = await dbContext.Images.FirstOrDefaultAsync(image => image.ParentPostId == postId);
            dbContext.Attach(post);
            {
                post.AttachedImage = image;
                post.Comments = comments;
                post.Content = updatedPost.Content;
                post.Title = updatedPost.Title;
            }
            await dbContext.SaveChangesAsync();
            return post;
        }
    }
}