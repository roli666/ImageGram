using ImageGram.Core.ApiModels;
using ImageGram.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ImageGram.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<PostController> logger;
        private readonly ICommentService commentService;

        public CommentController(ILogger<PostController> logger, ICommentService commentService)
        {
            this.logger = logger;
            this.commentService = commentService;
        }

        [HttpPost("/Comment")]
        public async Task<IActionResult> CreateComment(CreateCommentDTO createCommentDTO)
        {
            var comment = await commentService.AddComment(createCommentDTO);
            return Ok(comment);
        }
    }
}
