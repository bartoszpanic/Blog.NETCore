using AutoMapper;
using Blog.NETCore.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.NETCore.Application.Functions.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, DeletePostCommandResponse>
    {
        private readonly IPostRepository _postRepository;

        public DeletePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<DeletePostCommandResponse> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeletePostCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new DeletePostCommandResponse(validationResult);
            }

            var postDelete = await _postRepository.GetByIdAsync(request.PostId);
            await _postRepository.DeleteAsync(postDelete);

            return new DeletePostCommandResponse(postDelete.PostId);
        }
    }
}
