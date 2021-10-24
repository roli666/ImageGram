using System.Collections.Generic;

namespace ImageGram.Core.ApiModels
{
    public class PostDTO : CreatePostDTO
    {
        public int Id { get; set; }
        public IEnumerable<CommentDTO> Comments { get; set; }
    }

    public class CreatePostDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public CreateImageDTO AttachedImage { get; set; } = null;
    }
}