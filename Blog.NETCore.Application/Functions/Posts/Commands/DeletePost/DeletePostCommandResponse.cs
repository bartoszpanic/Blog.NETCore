using Blog.NETCore.Application.Response;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Posts.Commands.DeletePost
{
    public class DeletePostCommandResponse : BaseResponse
    {
        public int? PostId { get; set; }

        public DeletePostCommandResponse() : base()
        {
        }
        public DeletePostCommandResponse(string message) : base(message)
        {
        }
        public DeletePostCommandResponse(string message, bool success) : base(message, success)
        {
        }
        public DeletePostCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }
        public DeletePostCommandResponse(int postId)
        {
            PostId = postId;
        }
    }
}
