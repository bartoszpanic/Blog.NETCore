using AutoMapper;
using Blog.NETCore.Application.Interfaces;
using Blog.NETCore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.NETCore.Application.Functions.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, UpdateCommentCommandResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<UpdateCommentCommandResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCommentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new UpdateCommentCommandResponse(validationResult);
            }

            var comment = _mapper.Map<Comment>(request);

            await _commentRepository.UpdateAsync(comment);

            return new UpdateCommentCommandResponse(comment.CommentId);
        }
    }
}
