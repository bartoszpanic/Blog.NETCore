using Blog.NETCore.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.NETCore.Application.Functions.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, DeleteCommentCommandResponse>
    {
        private readonly ICommentRepository _commentRepository;
        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<DeleteCommentCommandResponse> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteCommentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new DeleteCommentCommandResponse(validationResult);
            }

            var commentDelete = await _commentRepository.GetByIdAsync(request.CommentId);
            await _commentRepository.DeleteAsync(commentDelete);

            return new DeleteCommentCommandResponse(commentDelete.CommentId);
        }
    }
}
