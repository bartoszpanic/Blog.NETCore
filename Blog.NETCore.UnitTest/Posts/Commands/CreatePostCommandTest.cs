using AutoMapper;
using Blog.NETCore.Application.Interfaces;
using Moq;
using System;
using Blog.NETCore.UnitTest.Mocks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.NETCore.Application.Mapper;
using Xunit;
using Blog.NETCore.Application.Functions.Posts.Commands.CreatePost;
using System.Threading;
using Shouldly;

namespace Blog.NETCore.UnitTest.Posts.Commands
{
    public class CreatePostCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPostRepository> _mockRepository;

        public CreatePostCommandTest()
        {
            _mockRepository = RepositoryMocks.GetPostRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidPost_AddedToPostRepo()
        {
            var handler = new CreatedPostCommandHandler(_mockRepository.Object, _mapper);

            var allPostsBeforeCount = (await _mockRepository.Object.GetAllAsync()).Count;

            var response = await handler.Handle(new CreatedPostCommand()
            {
                Title = "Test",
                Content = "Test",
                Description = "Test"
            }, CancellationToken.None);

            var allPosts = await _mockRepository.Object.GetAllAsync();

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            allPosts.Count.ShouldBe(allPostsBeforeCount + 1);
            response.PostId.ShouldNotBeNull();
        }

        [Fact]
        public async Task Handle_Not_ValidPost_TooLongTitle_81_Characters_NotAddedToRepo()
        {
            var handler = new CreatedPostCommandHandler(_mockRepository.Object, _mapper);
            var allPostBeforeCount = (await _mockRepository.Object.GetAllAsync()).Count;

            var command = new CreatedPostCommand()
            {
                Title = new string('*', 81),
                Description = "Test",
                Content = "test"
            };

            var response = await handler.Handle(command, CancellationToken.None);

            var allPosts = await _mockRepository.Object.GetAllAsync();

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(1);
            allPosts.Count.ShouldBe(allPostBeforeCount);
            response.PostId.ShouldBeNull();
        }
    }
}
