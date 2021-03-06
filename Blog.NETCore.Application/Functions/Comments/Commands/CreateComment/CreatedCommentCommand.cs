using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Comments.Commands.CreateComment
{
    public class CreatedCommentCommand : IRequest<CreatedCommentCommandResponse>
    {
        public int CommentId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
    }
}
