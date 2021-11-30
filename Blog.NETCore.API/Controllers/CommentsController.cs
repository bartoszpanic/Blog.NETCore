using Blog.NETCore.Application.Functions.Comments.Commands.CreateComment;
using Blog.NETCore.Application.Functions.Comments.Commands.DeleteComment;
using Blog.NETCore.Application.Functions.Comments.Commands.UpdateComment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.NETCore.API.Controllers
{
    [Route("api/posts/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddComment")]
        public async Task<ActionResult<CreatedCommentCommandResponse>> Create([FromBody] CreatedCommentCommand createdCategoryCommand)
        {
            var response = await _mediator.Send(createdCategoryCommand);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Update([FromBody] UpdateCommentCommand updateCommentCommand)
        {
            var result = await _mediator.Send(updateCommentCommand);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteComment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deteleCommentCommand = new DeleteCommentCommand() { CommentId = id };
            await _mediator.Send(deteleCommentCommand);
            return NoContent();
        }
    }
}
