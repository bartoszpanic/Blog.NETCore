using Blog.NETCore.Application.Response;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandResponse : BaseResponse
    {
        public int? CommentId { get; set; }
        public UpdateCommentCommandResponse() : base()
        {
        }
        public UpdateCommentCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }
        public UpdateCommentCommandResponse(string message) : base(message)
        {
        }
        public UpdateCommentCommandResponse(string message, bool success) : base(message, success)
        {
        }
        public UpdateCommentCommandResponse(int commentId)
        {
            CommentId = commentId;
        }
    }
}
