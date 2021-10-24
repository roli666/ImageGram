using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace ImageGram.Infrastructure.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public int ParentPostId { get; set; }
        public Post ParentPost { get; set; }
        public string FileName { get; set; }
        public Image(int parentPostId)
        {
            ParentPostId = parentPostId;
            Id = Guid.NewGuid();
            FileName = $"{ParentPostId}_${Id}.jpg";
        }
    }
}
