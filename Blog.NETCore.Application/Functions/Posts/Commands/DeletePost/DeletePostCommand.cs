using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest<DeletePostCommandResponse>
    {
        public int PostId { get; set; }
    }
}
