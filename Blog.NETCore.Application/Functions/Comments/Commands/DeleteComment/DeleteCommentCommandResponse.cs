using Blog.NETCore.Application.Response;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandResponse : BaseResponse
    {
        public int? CommentId { get; set; }

        public DeleteCommentCommandResponse() : base()
        {
        }
        public DeleteCommentCommandResponse(string message) : base(message)
        {
        }
        public DeleteCommentCommandResponse(string message, bool success) : base(message, success)
        {
        }
        public DeleteCommentCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }
        public DeleteCommentCommandResponse(int commentId)
        {
            CommentId = commentId;
        }
    }
}
