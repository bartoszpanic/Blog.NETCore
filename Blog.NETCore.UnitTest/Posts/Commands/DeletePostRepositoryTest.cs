using AutoMapper;
using Blog.NETCore.Application.Functions.Posts.Commands.DeletePost;
using Blog.NETCore.Application.Interfaces;
using Blog.NETCore.Application.Mapper;
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

namespace Blog.NETCore.UnitTest.Posts.Commands
{
    public class DeletePostRepositoryTest
    {
        private readonly Mock<IPostRepository> _mockRepository;

        public DeletePostRepositoryTest()
        {
            _mockRepository = RepositoryMocks.GetPostRepository();
        }
        [Fact]
        public async Task Handle_ValidPost_DeletedFromPostRepo() 
        {
            var handler = new DeletePostCommandHandler(_mockRepository.Object);

            var allPostsBeforeCount = (await _mockRepository.Object.GetAllAsync()).Count;

            var response = await handler.Handle(new DeletePostCommand()
            {
                PostId = 1
            }, CancellationToken.None);

            var allPosts = await _mockRepository.Object.GetAllAsync();

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            allPosts.Count.ShouldBe(allPostsBeforeCount - 1);
            response.PostId.ShouldNotBeNull();
        }
    }
}
