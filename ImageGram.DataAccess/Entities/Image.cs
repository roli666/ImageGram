using System;

namespace ImageGram.Infrastructure.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public int ParentPostId { get; set; }
        public Post ParentPost { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }

        public Image(string extension, int parentPostId)
        {
            ParentPostId = parentPostId;
            Extension = extension;
            Id = Guid.NewGuid();
            FileName = $"{ParentPostId}_${Id}.{Extension}";
        }
    }
}