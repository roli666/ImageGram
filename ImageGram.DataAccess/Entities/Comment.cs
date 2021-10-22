using ImageGram.SharedKernel;
using System;

namespace ImageGram.Infrastructure.Entities
{
    public class Comment : BaseEntity
    {
        public int ParentPostId { get; set; }
        public Post ParentPost { get; set; }
        public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
        public string Content { get; set; }
    }
}