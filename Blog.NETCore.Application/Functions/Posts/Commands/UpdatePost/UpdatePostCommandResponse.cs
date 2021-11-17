using Blog.NETCore.Application.Response;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using Blog.NETCore.Application.Response;
using System.Text;
using FluentValidation.Results;

namespace Blog.NETCore.Application.Functions.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandResponse : BaseResponse
    {
        public int? PostId { get; set; }

        public UpdatePostCommandResponse() : base()
        {
        }
        public UpdatePostCommandResponse(string message) : base(message)
        {
        }
        public UpdatePostCommandResponse(string message, bool success) : base(message, success)
        {
        }
        public UpdatePostCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }
        public UpdatePostCommandResponse(int postId)
        {
            PostId = postId;
        }
    }
}
