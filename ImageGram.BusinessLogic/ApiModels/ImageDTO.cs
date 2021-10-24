using ImageGram.Core.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Text.Json.Serialization;

namespace ImageGram.Core.ApiModels
{
    public class ImageDTO : CreateImageDTO
    {
        public Guid Id { get; set; }
    }

    public class CreateImageDTO
    {
        public int ParentPostId { get; set; }
        public ContentType ContentType { get; set; }

        [MaxLength(102400)]
        [JsonConverter(typeof(Base64FileJsonConverter))]
        public byte[] ImageBytes { get; set; }
    }
}