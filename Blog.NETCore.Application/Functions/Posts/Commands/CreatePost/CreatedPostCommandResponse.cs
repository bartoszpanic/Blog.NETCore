using Blog.NETCore.Application.Response;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Posts.Commands.CreatePost
{
    public class CreatedPostCommandResponse : BaseResponse
    {
        public int? PostId { get; set; }

        public CreatedPostCommandResponse() : base()
        {
        }
        public CreatedPostCommandResponse(string message) : base(message)
        {
        }
        public CreatedPostCommandResponse(string message, bool success) : base(message, success)
        {
        }
        public CreatedPostCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }
        public CreatedPostCommandResponse(int postId)
        {
            PostId = postId;
        }
    }
}
