using Blog.NETCore.Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Comments.Commands.CreateComment
{
    public class CreatedCommentCommandValidator : AbstractValidator<CreatedCommentCommand>
    {
        public CreatedCommentCommandValidator()
        {
            RuleFor(c => c.Author)
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MaximumLength(30)
                .WithMessage("{PropertyName} must not exceed between 30 characters");

            RuleFor(c => c.Content)
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MaximumLength(200)
                .WithMessage("{PropertyName} must not exceed between 20 characters");

            RuleFor(c => c.PostId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .WithMessage("{PropertyName} is required");
        }
    }
}
