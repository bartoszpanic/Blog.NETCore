using Blog.NETCore.Application.Functions.Comments.Commands.DeleteComment;
using Blog.NETCore.Application.Interfaces;
using Blog.NETCore.UnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Blog.NETCore.UnitTest.Comments.Commands
{
    public class DeleteCommentRepositoryTest
    {
        private readonly Mock<ICommentRepository> _mockRepository;

        public DeleteCommentRepositoryTest()
        {
            _mockRepository = RepositoryMocks.GetCommentRepository();
        }
        [Fact]
        public async Task Handle_ValidPost_DeletedFromPostRepo()
        {
            var handler = new DeleteCommentCommandHandler(_mockRepository.Object);

            var allPostsBeforeCount = (await _mockRepository.Object.GetAllAsync()).Count;

            var response = await handler.Handle(new DeleteCommentCommand()
            {
                CommentId = 1,
                PostId = 1
            }, CancellationToken.None);

            var allPosts = await _mockRepository.Object.GetAllAsync();

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            allPosts.Count.ShouldBe(allPostsBeforeCount - 1);
            response.CommentId.ShouldNotBeNull();
        }
    }
}
