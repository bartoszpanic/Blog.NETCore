using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Posts.Queries.GetPostDetailWithComments
{
    public class GetPostDetailWithCommentsQuery : IRequest<GetPostDetailQueryResponse>
    {
        public int PostId { get; set; }
    }
}
