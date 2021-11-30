using Blog.NETCore.Application.Functions.Posts.Commands.CreatePost;
using Blog.NETCore.Application.Functions.Posts.Commands.DeletePost;
using Blog.NETCore.Application.Functions.Posts.Commands.UpdatePost;
using Blog.NETCore.Application.Functions.Posts.Queries.GetPostDetailWithComments;
using Blog.NETCore.Application.Functions.Posts.Queries.GetPostsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.NETCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PostsController> _logger;
        public PostsController(IMediator mediator, ILogger<PostsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet(Name = "GetAllPosts")]
        public async Task<ActionResult<List<PostInListViewModel>>> GetAllPosts()
        {
            var list = await _mediator.Send(new GetPostInListQuery());
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetPostById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PostDetailWithCommentListViewModel>> GetPostById(int id)
        {
            var detailViewModel = await _mediator.Send(new GetPostDetailWithCommentsQuery() { PostId = id });
            return Ok(detailViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreatedPostCommand createdPostCommand)
        {
            _logger.LogInformation("Create post action invoked");
            var result = await _mediator.Send(createdPostCommand);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Update([FromBody] UpdatePostCommand updatePostCommand)
        {
            var result = await _mediator.Send(updatePostCommand);
            _logger.LogInformation($"Post with id : {updatePostCommand.PostId}, Update action invoked");
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeletePost")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogWarning("Delete post action invoked");
            var detelePostCommand = new DeletePostCommand() { PostId = id };
            await _mediator.Send(detelePostCommand);
            return NoContent();
        }
    }
}
