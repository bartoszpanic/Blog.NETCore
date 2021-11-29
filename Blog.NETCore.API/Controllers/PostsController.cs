using Blog.NETCore.Application.Functions.Posts.Commands.CreatePost;
using Blog.NETCore.Application.Functions.Posts.Commands.DeletePost;
using Blog.NETCore.Application.Functions.Posts.Commands.UpdatePost;
using Blog.NETCore.Application.Functions.Posts.Queries.GetPostDetailWithComments;
using Blog.NETCore.Application.Functions.Posts.Queries.GetPostsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.NETCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
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
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeletePost")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var detelePostCommand = new DeletePostCommand() { PostId = id };
            await _mediator.Send(detelePostCommand);
            return NoContent();
        }
    }
}
