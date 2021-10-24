﻿using ImageGram.Core.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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