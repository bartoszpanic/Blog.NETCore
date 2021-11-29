using AutoMapper;
using Blog.NETCore.Application.Functions.Posts.Queries.GetPostsList;
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

namespace Blog.NETCore.UnitTest.Posts.Query
{
    public class GetPostsListQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPostRepository> _mockRepository;

        public GetPostsListQueryHandlerTest()
        {
            _mockRepository = RepositoryMocks.GetPostRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
        //[Fact]
        //public async Task Get_Post_List_Test()
        //{
        //    var handler = new GetPostsListQueryHandler(_mockRepository.Object, _mapper);

        //    var result = await handler.Handle(new GetPostInListQuery(), CancellationToken.None);

        //    result.ShouldBeOfType<GetPostInListQueryResponse>();
        //}
    }
}
