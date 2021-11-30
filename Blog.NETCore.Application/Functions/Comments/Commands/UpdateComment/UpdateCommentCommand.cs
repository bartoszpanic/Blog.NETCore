using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<UpdateCommentCommandResponse>
    {
        public int CommentId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
    }
}
