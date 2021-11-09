using AutoMapper;
using Blog.NETCore.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.NETCore.Application.Functions.Posts.Queries.GetPostsList
{
    public class GetPostsListQueryHandler : IRequestHandler<GetPostInListQuery, List<PostInListViewModel>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public GetPostsListQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }
        public async Task<List<PostInListViewModel>> Handle(GetPostInListQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAllAsync();
            return _mapper.Map<List<PostInListViewModel>>(posts);
        }
    }
}
