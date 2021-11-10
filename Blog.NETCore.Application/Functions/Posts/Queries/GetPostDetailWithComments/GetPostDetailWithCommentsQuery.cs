using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Posts.Queries.GetPostDetailWithComments
{
    public class GetPostDetailWithCommentsQuery : IRequest<PostDetailWithCommentListViewModel>
    {
        public int PostId { get; set; }
    }
}
