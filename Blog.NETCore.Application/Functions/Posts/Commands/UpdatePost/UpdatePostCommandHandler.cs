using AutoMapper;
using Blog.NETCore.Application.Interfaces;
using Blog.NETCore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.NETCore.Application.Functions.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, UpdatePostCommandResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<UpdatePostCommandResponse> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePostCommandValidator(_postRepository);
            var validationResut = await validator.ValidateAsync(request);
            if (!validationResut.IsValid)
            {
                return new UpdatePostCommandResponse(validationResut);
            }

            var post = _mapper.Map<Post>(request);
            await _postRepository.UpdateAsync(post);

            return new UpdatePostCommandResponse(post.PostId);
        }
    }
}
