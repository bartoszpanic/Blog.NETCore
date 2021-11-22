using AutoMapper;
using Blog.NETCore.Application.Functions.Comments.Commands.CreateComment;
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

namespace Blog.NETCore.UnitTest.Comments.Commands
{
    public class CreateCommentCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICommentRepository> _mockRepository;

        public CreateCommentCommandTest()
        {
            _mockRepository = RepositoryMocks.GetCommentRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidComment_AddedToRepo()
        {
            var handler = new CreatedCommentCommandHandler(_mockRepository.Object, _mapper);

            var allCommentsBeforeCount = (await _mockRepository.Object.GetAllAsync()).Count;

            var response = await handler.Handle(new CreatedCommentCommand()
            {
                Author = "Test",
                Content = "Test",
                PostId = 1
            }, CancellationToken.None);

            var allComments = await _mockRepository.Object.GetAllAsync();

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            allComments.Count.ShouldBe(allCommentsBeforeCount + 1);
            response.CommentId.ShouldNotBeNull();
        }
    }
}
