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
    public class GetPostsListQueryHandler : IRequestHandler<GetPostInListQuery, GetPostInListQueryResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public GetPostsListQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }
        public async Task<GetPostInListQueryResponse> Handle(GetPostInListQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAllAsync();
            var mapped = _mapper.Map<List<PostInListViewModel>>(posts);

            return new GetPostInListQueryResponse(mapped);
        }
    }
}
