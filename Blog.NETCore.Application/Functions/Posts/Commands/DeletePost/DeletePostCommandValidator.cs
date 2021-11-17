using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Posts.Commands.DeletePost
{
    public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
    {
        public DeletePostCommandValidator()
        {
            RuleFor(p => p.PostId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .WithMessage("{PropertyName} is required");
        }
    }
}
