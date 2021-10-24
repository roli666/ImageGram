using ImageGram.Core.ApiModels;
using ImageGram.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGram.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> logger;
        private readonly IPostService postService;
        private readonly IImageService imageService;
        private readonly IFileService fileService;

        public PostController(ILogger<PostController> logger, IPostService postService, IImageService imageService, IFileService fileService)
        {
            this.logger = logger;
            this.postService = postService;
            this.imageService = imageService;
            this.fileService = fileService;
        }

        [HttpPost("/Post")]
        public async Task<IActionResult> CreatePost(CreatePostDTO post)
        {
            logger.LogInformation("Creating new post...");
            var createdPost = await postService.CreatePost(post);
            if (post.AttachedImage != null)
            {
                var validation = imageService.ValidateImage(post.AttachedImage.ImageBytes);
                if (!validation)
                    return ValidationProblem("Image has invalid extension.");
                var image = await imageService.CreateImage(post.AttachedImage);
                var postWithImage = await postService.UpdatePost(createdPost.Id, new CreatePostDTO
                {
                    AttachedImage = new ImageDTO
                    {
                        Id = image.Id,
                    },
                    Content = createdPost.Content,
                    Title = createdPost.Title
                });
                return Ok(postWithImage);
            }

            return Ok(createdPost);
        }

        [HttpGet("/Posts")]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await postService.GetPosts();
            return Ok(posts.OrderByDescending(post => post.Comments.Count()));
        }

        [HttpGet("/Post/Image/{postId}")]
        public async Task<IActionResult> GetImage(int postId)
        {
            var post = await postService.GetPost(postId);
            var stream = fileService.ServeImage(post.AttachedImage);

            return File(stream, "image/jpg");
        }

        [HttpGet("/Posts/{postId}/{postCount}")]
        public async Task<IActionResult> GetPosts(int cursor, int postCount)
        {
            var posts = await postService.GetPosts();
            return Ok(posts.OrderBy(post => post.Id).Where(post => post.Id > cursor).Take(postCount).OrderByDescending(post => post.Comments.Count()));
        }
    }
}