using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentCommandValidator()
        {
            RuleFor(c => c.CommentId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .WithMessage("{PropertyName} is required");

            RuleFor(c => c.PostId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .WithMessage("{PropertyName} is required");
        }
    }
}
