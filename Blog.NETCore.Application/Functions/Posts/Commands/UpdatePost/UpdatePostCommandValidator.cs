using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {
            RuleFor(p => p.Title)
               .NotEmpty()
               .WithMessage("{PropertyName} is required")
               .NotNull()
               .MaximumLength(80)
               .WithMessage("{PropertyName} must not exceed between 80 characters");

            RuleFor(p => p.Content)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MaximumLength(1000)
                .WithMessage("{PropertyName} must not exceed between 1000 characters");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(200)
                .WithMessage("{PropertyName} must not exceed between 1000 characters");
        }
    }
}
