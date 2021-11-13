using Blog.NETCore.Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Comments.Commands
{
    public class CreatedCommentCommandValidator : AbstractValidator<CreatedCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;
        public CreatedCommentCommandValidator(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;

            RuleFor(c => c.Author)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MaximumLength(30)
                .WithMessage("{PropertyName} must not exceed between 80 characters");

            RuleFor(c => c.Content)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MaximumLength(200)
                .WithMessage("{PropertyName} must not exceed between 80 characters");
        }
    }
}
