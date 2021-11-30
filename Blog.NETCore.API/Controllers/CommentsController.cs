using Blog.NETCore.Application.Functions.Comments.Commands.CreateComment;
using Blog.NETCore.Application.Functions.Comments.Commands.DeleteComment;
using Blog.NETCore.Application.Functions.Comments.Commands.UpdateComment;
using Blog.NETCore.Application.Middleware.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Blog.NETCore.API.Controllers
{
    [Route("api/posts/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CommentsController> _logger;
        public CommentsController(IMediator mediator, ILogger<CommentsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "AddComment")]
        public async Task<ActionResult<CreatedCommentCommandResponse>> Create([FromBody] CreatedCommentCommand createdCategoryCommand)
        {
            _logger.LogInformation("Create comment action invoked");
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
            _logger.LogInformation($"Comment with id : {updateCommentCommand.CommentId}, Update action invoked");
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteComment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogWarning($"Comment with id : {id}, Delete action invoked");

            var deteleCommentCommand = new DeleteCommentCommand() { CommentId = id };
            await _mediator.Send(deteleCommentCommand);
            return NoContent();
        }
    }
}
