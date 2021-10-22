namespace ImageGram.Core.ApiModels
{
    public class CommentDTO : CreateCommentDTO
    {
        public int Id { get; set; }
        public PostDTO ParentPost { get; set; }
    }

    public class CreateCommentDTO
    {
        public int ParentPostId { get; set; }
        public string Content { get; set; }
    }
}