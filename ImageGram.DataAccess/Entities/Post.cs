using ImageGram.SharedKernel;
using System.Collections.Generic;

namespace ImageGram.Infrastructure.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Image AttachedImage { get; set; } = null;
        public IEnumerable<Comment> Comments { get; set; }
    }
}