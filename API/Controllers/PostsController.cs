using Microsoft.AspNetCore.Mvc;
using prosigliere_coding_challenge.Domain.Commands;
using prosigliere_coding_challenge.Domain.Handlers;
using prosigliere_coding_challenge.Domain.Repositories;
using System.Threading.Tasks;

namespace prosigliere_coding_challenge.Controllers
{
    public class PostsController : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostCommand command, [FromServices] BlogPostsHandler handler)
        {
            var result = (GenericCommandResult)(await handler.Handle(command));
            if (!result.Sucess)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("")]
        public async Task<IEnumerable<Domain.Entities.BlogPost>> GetAll(
            [FromServices] IBlogPostsRepository repository) => await repository.GetAll();

        [HttpGet("{id:guid}")]
        public async Task<Domain.Entities.BlogPost> GetById(
            [FromRoute] Guid id,
            [FromServices] IBlogPostsRepository repository) => await repository.GetById(id);


        [HttpGet("{id:guid}/comments/{commentid:guid}")]
        public async Task<Domain.Entities.Comment> GetComments(
            [FromRoute] Guid id, [FromRoute] Guid commentid,
            [FromServices] ICommentsRepository repository) => await repository.GetById(commentid);

        [HttpGet("{id:guid}/comments")]
        public async Task<IEnumerable<Domain.Entities.Comment>> GetCommentsFromPost(
            [FromRoute] Guid id,
            [FromServices] ICommentsRepository repository) => await repository.GetByPostId(id);

        [HttpPost("{id:guid}/comments")]
        public async Task<IActionResult> CreateComment([FromRoute]Guid id,[FromBody] CreateCommentCommand command, [FromServices] CommentsHandler handler)
        {
            if(id != command.BlogPostId)
            {
                return BadRequest("Invalid BlogPostId");
            }

            var result = (GenericCommandResult)(await handler.Handle(command));


            if (!result.Sucess)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
