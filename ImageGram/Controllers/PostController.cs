using ImageGram.Core.ApiModels;
using ImageGram.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;

namespace ImageGram.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostService postService;

        public PostController(ILogger<PostController> logger, IPostService postService)
        {
            _logger = logger;
            this.postService = postService;
        }

        [HttpPost("/Post")]
        public async Task<IActionResult> CreatePost(PostDTO post)
        {
            await postService.CreatePost(post);
            return Ok();
        }

        [HttpGet("/GetPosts")]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await postService.GetPosts();
            return Ok(posts.OrderByDescending(post => post.Comments.Count()));
        }

        [HttpGet("/GetPosts/{id}/{take}")]
        public async Task<IActionResult> GetPosts(int cursor, int size)
        {
            var posts = await postService.GetPosts();
            return Ok(posts.OrderBy(post => post.Id).Where(post => post.Id > cursor).Take(size).OrderByDescending(post => post.Comments.Count()));
        }
    }
}