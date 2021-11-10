using AutoMapper;
using Blog.NETCore.Application.Interfaces;
using Blog.NETCore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.NETCore.Application.Functions.Posts.Commands.CreatePost
{
    public class CreatedPostCommandHandler : IRequestHandler<CreatedPostCommand, int>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public CreatedPostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<int> Handle(CreatedPostCommand request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Post>(request);
            post = await _postRepository.AddAsync(post);

            return post.PostId;
        }
    }
}
