using ImageGram.Core.ApiModels;
using ImageGram.Core.Interfaces;
using ImageGram.Infrastructure.Data;
using ImageGram.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ImageGram.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly ImageGramDBContext dbContext;

        public CommentService(ImageGramDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Comment> AddComment(CreateCommentDTO comment)
        {
            var newComment = dbContext.Comments.Add(new Comment
            {
                Content = comment.Content,
                ParentPostId = comment.ParentPostId
            });
            await dbContext.SaveChangesAsync();
            return newComment.Entity;
        }

        public async Task<Comment> RemoveComment(int commentId)
        {
            var comment = await dbContext.Comments.FirstOrDefaultAsync(comment => comment.Id == commentId);
            dbContext.Comments.Remove(comment);
            await dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> UpdateComment(CommentDTO commentDto)
        {
            var comment = await dbContext.Comments.FirstOrDefaultAsync(comment => comment.Id == commentDto.Id);
            dbContext.Attach(comment);
            {
                comment.Content = commentDto.Content;
                comment.Created = DateTimeOffset.Now;
            }
            await dbContext.SaveChangesAsync();
            return comment;
        }
    }
}