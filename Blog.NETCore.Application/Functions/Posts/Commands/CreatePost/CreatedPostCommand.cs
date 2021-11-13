using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Posts.Commands.CreatePost
{
    public class CreatedPostCommand : IRequest<CreatedPostCommandResponse>
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
