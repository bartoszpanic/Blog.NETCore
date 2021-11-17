using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest<DeleteCommentCommandResponse>
    {
        public int CommentId { get; set; }
    }
}
